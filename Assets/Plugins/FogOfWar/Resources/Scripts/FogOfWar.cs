using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System;

public static class FogOfWar
{
    public enum Players {
        Player00 = 1,
        Player01 = 2,
        Player02 = 4,
        Player03 = 8
        /*
        For more Factions, uncomment if needed
        ,
        Player04 = 16,
        Player05 = 32,
        Player06 = 64,
        Player07 = 128
        */
    };
    public enum FogAlignment
    {
        Horizontal, Vertical
    };
    public enum FogEffect
    {
        None, Color, AnimatedFog
    };
    public enum MapSizes
    {
        _16, _32, _64, _128, _256, _512
    };
    public enum FogQuality
    {
        Off, On
    };
    public enum TerrainMaterial
    {
        Standard, Legacy_Diffuse, Legacy_Specular
    };

    public static FogAlignment fogAlignment;    //Alignment 0 = Horizontal, 1 = Vertical

    public static List<Faction> Factions = new List<Faction>();
    private static List<Revealer> FogOfWarRevealer = new List<Revealer>();
    private static List<Vector3> FogOfWarRevealerPositions = new List<Vector3>();
    private static List<GameObject> FogOfWarVisionBlocker = new List<GameObject>();
    private static List<Vector3> FogOfWarVisionBlockerPositions = new List<Vector3>();
    public static Color[] ResistenceMapData;

    public static float MainThreadDeltaTime;

    private static float VisionRange;
    private static int StartX;
    private static int StartY;
    private static int LevelWidth;
    private static int LevelHeight;

    private static bool ScalePatchModifier;
    private static float PatchScale = 1f;
    private static Vector3 Origin = Vector3.zero;

    public static FogOfWar.Players RevealFaction = FogOfWar.Players.Player00;
    public static int RevealFactionInt = 0;
    public static Color RevealOpacities = new Color(1.0f, 0.5f, 0.2f, 1.0f);
    public static bool ShowBlocker;
    public static bool UpdateAllFactions = true;
    public static bool UpdateFoV = true;

    //Buffer
    private static int PosX = 0;
    private static int PosZ = 0;
    private static int TestPosX = 0;
    private static int TestPosZ = 0;

    public static int GetRevealerCount()
    {
        return FogOfWarRevealer.Count;
    }

    public static void PrepareThread()
    {
        if (ScalePatchModifier)
        {
            int RevealerCount = FogOfWarRevealer.Count;

            for (int i = 0; i < RevealerCount; i++)
            {
                FogOfWarRevealerPositions[i] = (FogOfWarRevealer[i].RevealerObject.transform.position - Origin) / PatchScale;
            }

            int VisionBlockerCount = FogOfWarVisionBlocker.Count;

            for (int i = 0; i < VisionBlockerCount; i++)
            {
                FogOfWarVisionBlockerPositions[i] = (FogOfWarVisionBlocker[i].transform.position - Origin) / PatchScale;
            }
        } else {
            int RevealerCount = FogOfWarRevealer.Count;

            for (int i = 0; i < RevealerCount; i++)
            {
                FogOfWarRevealerPositions[i] = FogOfWarRevealer[i].RevealerObject.transform.position;
            }

            int VisionBlockerCount = FogOfWarVisionBlocker.Count;

            for (int i = 0; i < VisionBlockerCount; i++)
            {
                FogOfWarVisionBlockerPositions[i] = FogOfWarVisionBlocker[i].transform.position;
            }
        }
    }
    
    public static List<Revealer> GetRevealers(FogOfWar.Players _Faction)
    {
        List<Revealer> AllREvealerOfFaction = new List<Revealer>();
        foreach (Revealer r in FogOfWarRevealer)
        {
            if (r.Faction == _Faction)
            {
                AllREvealerOfFaction.Add(r);
            }
        }
        return AllREvealerOfFaction;
    }
    
    public static Color[] GetFogMapData(int _Faction)
    {
        return FogOfWar.Factions[_Faction].FogOfWarMapData;
    }

    public static void SetFogMapData(int _Faction, Color[] _Data)
    {
        Factions[_Faction].FogOfWarMapData = _Data;
    }

    public static void RegisterRevealer(Revealer _Revealer)
    {
        FogOfWarRevealer.Add(_Revealer);
        FogOfWarRevealerPositions.Add(Vector3.zero);
    }

    public static void RegisterVisionBlocker(GameObject _VisionBlocker)
    {
        FogOfWarVisionBlocker.Add(_VisionBlocker);
        FogOfWarVisionBlockerPositions.Add(Vector3.zero);
    }

    public static void UnRegisterRevealer(Revealer _Revealer)
    {
        for (int i = 0; i < FogOfWarRevealer.Count; i++)
        {
            if (_Revealer.RevealerObject.GetInstanceID() == FogOfWarRevealer[i].RevealerObject.GetInstanceID())
            {
                FogOfWarRevealer.RemoveAt(i);
                FogOfWarRevealerPositions.RemoveAt(i);
            }
        }
    }

    public static void UnRegisterVisionBlocker(GameObject _VisionBlocker)
    {
        for (int i = 0; i < FogOfWarVisionBlocker.Count; i++)
        {
            if (_VisionBlocker.GetInstanceID() == FogOfWarVisionBlocker[i].GetInstanceID())
            {
                FogOfWarVisionBlocker.RemoveAt(i);
                FogOfWarVisionBlockerPositions.RemoveAt(i);
            }
        }
    }

    public static void ResetFog(float _RevealSpeed, float _CoverSpeed)
    {
        int FactionCount = Factions.Count;
        
        for (int f = 0; f < Factions.Count; f++)
        {
            Color[] DataBuffer = Factions[f].FogOfWarMapDataBuffer;

            int FMDLength = Factions[f].FogOfWarMapData.Length;

            for (int i = 0; i < FMDLength; i++)
            {
                //Covered
                if (DataBuffer[i].r == 0.0f)
                {
                    DataBuffer[i].g = Mathf.Lerp(DataBuffer[i].g, RevealOpacities.b, _CoverSpeed * MainThreadDeltaTime);   //Covering
                }

                //Covered but was revealed once
                if (DataBuffer[i].r == 0.5f)
                {
                    DataBuffer[i].g = Mathf.Lerp(DataBuffer[i].g, RevealOpacities.g, _CoverSpeed * MainThreadDeltaTime);   //Covering
                }

                //Uncovered
                if (DataBuffer[i].r == 1.0f)
                {
                    DataBuffer[i].g = Mathf.Lerp(DataBuffer[i].g, RevealOpacities.r, _RevealSpeed * MainThreadDeltaTime);   //Revealing

                    if(UpdateFoV)
                    {
                        DataBuffer[i].r = 0.5f;                                                                             //Cover next frame if not revealed again!
                    }                                                                       
                }
            }
        }
    }

    public static void SetResistenceMapData(Color[] _ResistenceMapData)
    {
        ResistenceMapData = _ResistenceMapData;
    }

    public static void PrepareDynamicBlockers()
    {
        int RMDLength = ResistenceMapData.Length;

        for (int i = 0; i < RMDLength; i++)
        {
            ResistenceMapData[i].b = 0.0f;
        }

        foreach (Vector3 v in FogOfWarVisionBlockerPositions)
        {
            if (fogAlignment == FogOfWar.FogAlignment.Horizontal)
            {
                int NewCoordinate = Mathf.FloorToInt(v.z) * LevelWidth + Mathf.FloorToInt(v.x);
                ResistenceMapData[NewCoordinate].b = 1.0f;
            }

            if (fogAlignment == FogOfWar.FogAlignment.Vertical)
            {
                int NewCoordinate = Mathf.FloorToInt(v.y) * LevelWidth + Mathf.FloorToInt(v.x);
                ResistenceMapData[NewCoordinate].b = 1.0f;
            }
        }
    }

    public static void InitializeFogOfWar(int _LevelWidth, int _LevelHeight, List<Faction> _Factions, Players _RevealFaction)
    {
        LevelWidth = _LevelWidth;
        LevelHeight = _LevelHeight;
        Factions = _Factions;
        RevealFaction = _RevealFaction;
    }

    public static void RevealFog(float _RevealSpeed, float _CoverSpeed)
    {
        FogOfWar.ResetFog(_RevealSpeed, _CoverSpeed);
        System.Array revealFactions = System.Enum.GetValues(typeof(Players));

        int FactionCount = Factions.Count;

        for (int f = 0; f < FactionCount; f++)
        {
            if (!Factions[f].UpdateInBackground && f != (int)RevealFaction)
            {
                continue;
            }

            if (UpdateFoV)
            {
                int RevealerCount = FogOfWarRevealer.Count;

                for (int r = 0; r < RevealerCount; r++)
                {
                    if (((int)Factions[f].RevealFactions & (int)FogOfWarRevealer[r].Faction) != 0)
                    {

                        if (fogAlignment == 0)
                        {
                            PosX = Mathf.FloorToInt(FogOfWarRevealerPositions[r].x);
                            PosZ = Mathf.FloorToInt(FogOfWarRevealerPositions[r].z);
                        }
                        else
                        {
                            PosX = Mathf.FloorToInt(FogOfWarRevealerPositions[r].x);
                            PosZ = Mathf.FloorToInt(FogOfWarRevealerPositions[r].y);
                        }

                        CalculateFOV(PosX, PosZ, FogOfWarRevealer[r].VisionRange, FogOfWarRevealer[r].UpVision, f);
                    }
                }
            }
            Array.Copy(Factions[f].FogOfWarMapDataBuffer, Factions[f].FogOfWarMapData, Factions[f].FogOfWarMapDataBuffer.Length);
        }
        UpdateFoV = false;
    }

    private static Color[] CalculateFOV(int _StartX, int _StartY, float _VisionRange, int _UpVision, int _Faction)
    {
        float upVision = (float)_UpVision / 255f;

        if (_StartX >= LevelWidth || _StartY >= LevelHeight || _StartX < 0 || _StartY < 0)
        {
            return null;
        }

        VisionRange = _VisionRange;
        StartX = _StartX;
        StartY = _StartY;

        int StartCoordinate = Mathf.FloorToInt(StartY) * LevelWidth + Mathf.FloorToInt(StartX);
        Factions[_Faction].FogOfWarMapDataBuffer[StartCoordinate].r = 1f;
        Factions[_Faction].FogOfWarMapDataBuffer[StartCoordinate].g = 1f;

        //Top Left
        CastLight(1, 1.0f, 0.0f, 0, 1, -1, 0, StartCoordinate, upVision, _Faction);
        CastLight(1, 1.0f, 0.0f, 1, 0, 0, -1, StartCoordinate, upVision, _Faction);

        //Top right
        CastLight(1, 1.0f, 0.0f, -1, 0, 0, -1, StartCoordinate, upVision, _Faction);
        CastLight(1, 1.0f, 0.0f, 0, -1, -1, 0, StartCoordinate, upVision, _Faction);

        ////Bottom Right
        CastLight(1, 1.0f, 0.0f, 0, -1, 1, 0, StartCoordinate, upVision, _Faction);
        CastLight(1, 1.0f, 0.0f, -1, 0, 0, 1, StartCoordinate, upVision, _Faction);

        //Bottom Left
        CastLight(1, 1.0f, 0.0f, 1, 0, 0, 1, StartCoordinate, upVision, _Faction);
        CastLight(1, 1.0f, 0.0f, 0, 1, 1, 0, StartCoordinate, upVision, _Faction);

        return Factions[_Faction].FogOfWarMapDataBuffer;
    }

    private static void CastLight( int _Row, float _Start, float _End, int _XX, int _XY, int _YX, int _YY, int _StartCoordinate, float _UpVision, int _Faction)
    {
        float newStart = 0.0f;
        if (_Start < _End)
        {
            return;
        }

        bool blocked = false;

        for (int distance = _Row; distance <= VisionRange && !blocked; distance++)
        {
            int deltaY = -distance;
            for (int deltaX = -distance; deltaX <= 0; deltaX++)
            {
                int currentX = StartX + deltaX * _XX + deltaY * _XY;
                int currentY = StartY + deltaX * _YX + deltaY * _YY;

                int coordinate = Mathf.FloorToInt(currentY) * LevelWidth + Mathf.FloorToInt(currentX);

                float leftSlope = (deltaX - 0.5f) / (deltaY + 0.5f);
                float rightSlope = (deltaX + 0.5f) / (deltaY - 0.5f);

                if (!(currentX >= 0 && currentY >= 0 && currentX < LevelWidth && currentY < LevelHeight) || _Start < rightSlope)
                {
                    continue;
                } else if (_End > leftSlope) {
                    break;
                }
                
                if (CalculateVisionRange(deltaX, deltaY) <= VisionRange)
                {
                    if (ShowBlocker)
                    {
                        Factions[_Faction].FogOfWarMapDataBuffer[coordinate].r = 1.0f;
                    } else {
                        if (!IsBlocked(coordinate, _StartCoordinate, _UpVision))
                        {
                            Factions[_Faction].FogOfWarMapDataBuffer[coordinate].r = 1.0f;
                        }  
                    }
                }

                if (blocked)
                {
                    if (IsBlocked(coordinate, _StartCoordinate, _UpVision))
                    {
                        newStart = rightSlope;
                        continue;
                    } else {
                        blocked = false;
                        _Start = newStart;
                    }
                } else {
                    if (IsBlocked(coordinate, _StartCoordinate, _UpVision) && distance < VisionRange)
                    {
                        blocked = true;
                        CastLight(distance + 1, _Start, leftSlope, _XX, _XY, _YX, _YY, _StartCoordinate, _UpVision, _Faction);
                        newStart = rightSlope;
                    }
                }
            }
        }

        return;
    }

    private static bool IsBlocked(int _Coordinate, int _StartCoordinate, float _UpVision)
    {
        if (ResistenceMapData[_Coordinate].r != 0.0f)
            return true;

        if (ResistenceMapData[_Coordinate].g - ResistenceMapData[_StartCoordinate].g > _UpVision)
            return true;

        if (ResistenceMapData[_Coordinate].b != 0.0f)
            return true;

        if (ResistenceMapData[_Coordinate].a != ResistenceMapData[_StartCoordinate].a && ResistenceMapData[_Coordinate].a != 1f)
            return true;

        return false;
    }

    private static float CalculateVisionRange(int _dx, int _dy)
    {
        _dx = Mathf.Abs(_dx);
        _dy = Mathf.Abs(_dy);
        return Mathf.Sqrt(_dx * _dx + _dy * _dy);
    }

    public static float Remap(float value, float From1, float To1, float From2, float To2)
    {
        return From2 + (value - From1) * (To2 - From2) / (To1 - From1);
    }

    public static bool IsPositionRevealedByFaction(Vector3 _Position, FogOfWar.Players _RevealingFaction)
    {
        if (ScalePatchModifier)
        {
            if (fogAlignment == FogAlignment.Horizontal)
            {
                TestPosX = Mathf.RoundToInt(Mathf.Floor((_Position.x - Origin.x) / PatchScale));
                TestPosZ = Mathf.RoundToInt(Mathf.Floor((_Position.z - Origin.z) / PatchScale));
            }

            if (fogAlignment == FogAlignment.Vertical)
            {
                TestPosX = Mathf.RoundToInt(Mathf.Floor((_Position.x - Origin.x) / PatchScale));
                TestPosZ = Mathf.RoundToInt(Mathf.Floor((_Position.y - Origin.y) / PatchScale));
            }
        } else {
            if (fogAlignment == FogAlignment.Horizontal)
            {
                TestPosX = Mathf.FloorToInt(_Position.x);
                TestPosZ = Mathf.FloorToInt(_Position.z);
            }

            if (fogAlignment == FogAlignment.Vertical)
            {
                TestPosX = Mathf.FloorToInt(_Position.x);
                TestPosZ = Mathf.FloorToInt(_Position.y);
            }
        }
        
        int Coordinate = TestPosZ * LevelWidth + TestPosX;

        if (Coordinate < 0)
        {
            Debug.LogWarning("[UFoW] The tested position lies outside of Fog frustum.");
            return false;
        }
 
        if (Factions[FogOfWar.RevealFactionInt].FogOfWarMapData[Coordinate].r >= 1f)
        {
            return true;
        } else {
            return false;
        }
    }

    public static void UpdateScaleModifiers(bool _ScalePatchModifier, float _PatchScale, Vector3 _Origin)
    {
        ScalePatchModifier = _ScalePatchModifier;
        PatchScale = _PatchScale;
        Origin = _Origin;
    }
}
