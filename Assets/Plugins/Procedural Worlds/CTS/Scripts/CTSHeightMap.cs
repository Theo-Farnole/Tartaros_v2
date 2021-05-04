using UnityEngine;
using System;
using System.Text;
using Debug = UnityEngine.Debug;

namespace CTS
{
    /// <summary>
    /// Utility class for managing HeightMaps / Arrays - borrowed from Gaia 2
    /// </summary>
    public class CTSHeightMap
    {
        protected int m_widthX;
        protected int m_depthZ;
        protected float[,] m_heights;
        protected bool m_isPowerOf2;
        protected float m_widthInvX;
        protected float m_depthInvZ;
        protected float m_statMinVal;
        protected float m_statMaxVal;
        protected double m_statSumVals;
        protected bool m_isDirty;
        protected byte[] m_metaData = new byte[0];

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CTSHeightMap()
        {
            Reset();
        }

        /// <summary>
        /// Construct a CTSHeightMap with given width and height
        /// </summary>
        /// <param name="width">Width of constructed CTSHeightMap</param>
        /// <param name="height">Height of constructed CTSHeightMap</param>
		public CTSHeightMap(int width, int depth) 
		{
            m_widthX = width;
            m_depthZ = depth;
            m_widthInvX = 1f / (float)(m_widthX);
            m_depthInvZ = 1f / (float)(m_depthZ);
            m_heights = new float[m_widthX, m_depthZ];
            m_isPowerOf2 = Math_IsPowerOf2(m_widthX) && Math_IsPowerOf2(m_depthZ);
            m_statMinVal = m_statMaxVal = 0f;
            m_statSumVals = 0;
            m_metaData = new byte[0];
            m_isDirty = false;
		}

        /// <summary>
        /// Create a CTSHeightMap from a float array
        /// </summary>
        /// <param name="source">Source array</param>
        public CTSHeightMap(float[,] source)
        {
            m_widthX = source.GetLength(0);
            m_depthZ = source.GetLength(1);
            m_widthInvX = 1f / (float)(m_widthX);
            m_depthInvZ = 1f / (float)(m_depthZ);
            m_heights = new float[m_widthX, m_depthZ];
            m_isPowerOf2 = Math_IsPowerOf2(m_widthX) && Math_IsPowerOf2(m_depthZ);
            m_statMinVal = m_statMaxVal = 0f;
            m_statSumVals = 0;
            m_metaData = new byte[0];
            Buffer.BlockCopy(source, 0, m_heights, 0, m_widthX * m_depthZ * sizeof(float));
            m_isDirty = false;
        }

        /// <summary>
        /// Create a height map from the particular slice passed in
        /// </summary>
        /// <param name="source">Height map arrays</param>
        /// <param name="slice">The slice to use</param>
        public CTSHeightMap(float[,,] source, int slice)
        {
            m_widthX = source.GetLength(0);
            m_depthZ = source.GetLength(1);
            m_widthInvX = 1f / (float)(m_widthX);
            m_depthInvZ = 1f / (float)(m_depthZ);
            m_heights = new float[m_widthX, m_depthZ];
            m_isPowerOf2 = Math_IsPowerOf2(m_widthX) && Math_IsPowerOf2(m_depthZ);
            m_statMinVal = m_statMaxVal = 0f;
            m_statSumVals = 0;
            m_metaData = new byte[0];

            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] = source[x, z, slice];
                }
            }

            m_isDirty = false;
        }

        /// <summary>
        /// Create a CTSHeightMap from an int array - beware of precision issues
        /// </summary>
        /// <param name="source">Source array</param>
        public CTSHeightMap(int[,] source)
        {
            m_widthX = source.GetLength(0);
            m_depthZ = source.GetLength(1);
            m_widthInvX = 1f / (float)(m_widthX);
            m_depthInvZ = 1f / (float)(m_depthZ);
            m_heights = new float[m_widthX, m_depthZ];
            m_isPowerOf2 = Math_IsPowerOf2(m_widthX) && Math_IsPowerOf2(m_depthZ);
            m_statMinVal = m_statMaxVal = 0f;
            m_statSumVals = 0;
            m_metaData = new byte[0];

            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] = (float)source[x, z];
                }
            }

            m_isDirty = false;
        }

        /// <summary>
        /// Create a height map that is a copy of another CTSHeightMap
        /// </summary>
        /// <param name="source">Source CTSHeightMap</param>
        public CTSHeightMap(CTSHeightMap source)
        {
            Reset();
            m_widthX = source.m_widthX;
            m_depthZ = source.m_depthZ;
            m_widthInvX = 1f / (float)(m_widthX);
            m_depthInvZ = 1f / (float)(m_depthZ);
            m_heights = new float[m_widthX, m_depthZ];
            m_isPowerOf2 = source.m_isPowerOf2;

            m_metaData = new byte[source.m_metaData.Length];
            for (int idx = 0; idx < source.m_metaData.Length; idx++)
            {
                m_metaData[idx] = source.m_metaData[idx];
            }

            Buffer.BlockCopy(source.m_heights, 0, m_heights, 0, m_widthX * m_depthZ * sizeof(float));

            m_isDirty = false;
        }

        #endregion 

        #region Data access

        /// <summary>
        /// Get width of the height map (x component)
        /// </summary>
        /// <returns>Height map width</returns>
        public int Width()
        {
            return m_widthX;
        }

        /// <summary>
        /// Get depth or height of the height map (z component)
        /// </summary>
        /// <returns>Height map depth</returns>
        public int Depth()
        {
            return m_depthZ;
        }

        /// <summary>
        /// Get min value - need to call update stats before calling this
        /// </summary>
        /// <returns>Min value</returns>
        public float MinVal()
        {
            return m_statMinVal;
        }

        /// <summary>
        /// Get max value - need to call update stats before calling this
        /// </summary>
        /// <returns>Max value</returns>
        public float MaxVal()
        {
            return m_statMaxVal;
        }

        /// <summary>
        /// Get sum of values - need to call update stats before calling this
        /// </summary>
        /// <returns>Sum of values</returns>
        public double SumVal()
        {
            return m_statSumVals;
        }

        /// <summary>
        /// Get the size of the CTSHeightMap for buffers
        /// </summary>
        /// <returns>Number of elements in the CTSHeightMap</returns>
        public int GetBufferSize()
        {
            return m_widthX * m_depthZ;
        }

        /// <summary>
        /// Get metadata
        /// </summary>
        /// <returns>Metadata</returns>
        public byte[] GetMetaData()
        {
            return m_metaData;
        }

        /// <summary>
        /// Get dirty flag ie we have been modified
        /// </summary>
        /// <returns></returns>
        public bool IsDirty()
        {
            return m_isDirty;
        }

        /// <summary>
        /// Set dirty flag
        /// </summary>
        /// <param name="dirty"></param>
        /// <returns></returns>
        public void SetDirty(bool dirty = true)
        {
            m_isDirty = dirty;
        }

        /// <summary>
        /// Clear the dirty flag
        /// </summary>
        public void ClearDirty()
        {
            m_isDirty = false;
        }

        /// <summary>
        /// Set metadata
        /// </summary>
        /// <param name="metadata">The metadata to set</param>
        public void SetMetaData(byte[] metadata)
        {
            m_metaData = new byte[metadata.Length];
            Buffer.BlockCopy(metadata, 0, m_metaData, 0, metadata.Length);
            m_isDirty = true;
        }

        /// <summary>
        /// Get height map heights
        /// </summary>
        /// <returns>Height map heights</returns>
        public float[,] Heights()
        {
            return  m_heights;
        }

        /// <summary>
        /// Get the heights as a 1D Array
        /// </summary>
        /// <returns>Heights as a 1D array</returns>
        public float[] Heights1D()
        {
            float[] result = new float[m_widthX * m_depthZ];
            Buffer.BlockCopy(m_heights, 0, result, 0, result.Length * sizeof(float));
            return result;
        }

        /// <summary>
        /// Set the array from the content of the supplied 1D array = assume its set up to be correct length
        /// </summary>
        /// <param name="heights"></param>
        public void SetHeights(float[] heights)
        {
            int size = (int)Mathf.Sqrt((float)heights.Length);
            if (size != m_widthX || size != m_depthZ)
            {
                Debug.LogError("SetHeights: Heights do not match. Aborting.");
                return;
            }
            Buffer.BlockCopy(heights, 0, m_heights, 0, heights.Length * sizeof(float));
            m_isDirty = true;
        }

        /// <summary>
        /// Copy the content of the supplied array into this array
        /// </summary>
        /// <param name="heights"></param>
        public void SetHeights(float [,] heights)
        {
            if (m_widthX != heights.GetLength(0) || m_depthZ != heights.GetLength(1))
            {
                Debug.LogError("SetHeights: Sizes do not match. Aborting.");
                return;
            }
            int size = heights.GetLength(0)*heights.GetLength(1);
            Buffer.BlockCopy(heights, 0, m_heights, 0, size * sizeof(float));
            m_isDirty = true;
        }

        /// <summary>
        /// Get height at the given location. If out of bounds will return nearest border.
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="z">z location</param>
        /// <returns></returns>
        public float GetSafeHeight(int x, int z)
        {
            if (x < 0) x = 0;
            if (z < 0) z = 0;
            if (x >= m_widthX) x = m_widthX - 1;
            if (z >= m_depthZ) z = m_depthZ - 1;
            return m_heights[x, z];
        }

        /// <summary>
        /// Set height at the given location. If out of bounds will set at nearest border.
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="z">z location</param>
        /// <returns></returns>
        public void SetSafeHeight(int x, int z, float height)
        {
            if (x < 0) x = 0;
            if (z < 0) z = 0;
            if (x >= m_widthX) x = m_widthX - 1;
            if (z >= m_depthZ) z = m_depthZ - 1;
            m_heights[x, z] = height;
            m_isDirty = true;
        }

        /// <summary>
        /// Get the interpolated height at the given location
        /// </summary>
        /// <param name="x">x location, range 0..1</param>
        /// <param name="z">z location, range 0..1</param>
        /// <returns>Interpolated height</returns>
        protected float GetInterpolatedHeight(float x, float z)
        {
            //Convert to scale of the CTSHeightMap
            x *= ((float)m_widthX - 1f);
            z *= ((float)m_depthZ - 1f);
            int x0 = (int)x;
            int z0 = (int)z;
            int x1 = x0 + 1;
            int z1 = z0 + 1;
            if (x1 >= m_widthX)
            {
                x1 = x0;
            }
            if (z1 >= m_depthZ)
            {
                z1 = z0;
            }
            float dx = x - x0;
            float dz = z - z0;
            float omdx = 1f - dx;
            float omdz = 1f - dz;
            return omdx * omdz * m_heights[x0, z0] +
                      omdx * dz * m_heights[x0, z1] +
                      dx * omdz * m_heights[x1, z0] +
                      dx * dz * m_heights[x1, z1];
        }

        /// <summary>
        /// Get and set the height at the given location
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="z">z location</param>
        /// <returns>Height at that location</returns>
        public float this[int x, int z]
        {
            get
            {
                return m_heights[x, z];
            }
            set
            {
                m_heights[x, z] = value;
                m_isDirty = true;
            }
        }

        /// <summary>
        /// Get and set the height at the location
        /// </summary>
        /// <param name="x">x location in 0..1f</param>
        /// <param name="z">z location in 0..1f</param>
        /// <returns>Height at that location</returns>
        public float this[float x, float z]
        {
            get
            {
                return GetInterpolatedHeight(x, z);
            }
            set
            {
                x *= ((float)m_widthX - 1f);
                z *= ((float)m_depthZ - 1f);
                m_heights[(int)x, (int)z] = value;
                m_isDirty = true;
            }
        }

        /// <summary>
        /// Set the level of the entire map to the supplied value
        /// </summary>
        /// <returns>This</returns>
        public CTSHeightMap SetHeight(float height)
        {
            float newLevel = Math_Clamp(0f, 1f, height);
            for (int hmX = 0; hmX < m_widthX; hmX++)
            {
                for (int hmZ = 0; hmZ < m_depthZ; hmZ++)
                {
                    m_heights[hmX, hmZ] = newLevel;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Get the height rnage for this map
        /// </summary>
        /// <param name="minHeight">Minimum height</param>
        /// <param name="maxHeight">Maximum height</param>
        public void GetHeightRange(ref float minHeight, ref float maxHeight)
        {
            float currHeight;
            maxHeight = float.MinValue;
            minHeight = float.MaxValue;
            for (int hmX = 0; hmX < m_widthX; hmX++)
            {
                for (int hmZ = 0; hmZ < m_depthZ; hmZ++)
                {
                    currHeight = m_heights[hmX, hmZ];
                    if (currHeight > maxHeight)
                    {
                        maxHeight = currHeight;
                    }
                    if (currHeight < minHeight)
                    {
                        minHeight = currHeight;
                    }
                }
            }
        }

        /// <summary>
        /// Get the slope at the designated location
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="z">z location</param>
        /// <returns>Steepness at tha location</returns>
        public float GetSlope(int x, int z)
        {
            float height = m_heights[x, z];

            // Compute the differentials by stepping 1 in both directions.
            float dx = m_heights[x + 1, z] - height;
            float dy = m_heights[x, z + 1] - height;

            // The "steepness" is the magnitude of the gradient vector, 
            // For a faster but not as accurate computation, you can just use abs(dx) + abs(dy)
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Get the slope at the designated location
        /// </summary>
        /// <param name="x">x location in range 0..1</param>
        /// <param name="z">z location in range 0..1</param>
        /// <returns>Steepness</returns>
        public float GetSlope(float x, float z)
        {
            float dX = (GetInterpolatedHeight(x + (m_widthInvX * 0.9f), z) - GetInterpolatedHeight(x - (m_widthInvX * 0.9f), z));
            float dZ = (GetInterpolatedHeight(x, z + (m_depthInvZ * 0.9f)) - GetInterpolatedHeight(x, (z - m_depthInvZ * 0.9f)));
            //float direction = (float)Math.Atan2(deltaZ, deltaX);
            return Math_Clamp(0f, 90f, (float)(Math.Sqrt((dX * dX) + (dZ * dZ)) * 10000));
        }

        /// <summary>
        /// Get the slope at the designated location
        /// </summary>
        /// <param name="x">x location in range 0..1</param>
        /// <param name="z">z location in range 0..1</param>
        /// <returns>Steepness</returns>
        public float GetSlope_a(float x, float z)
        {
            float center = GetInterpolatedHeight(x, z);
            float dTop = Math.Abs(GetInterpolatedHeight(x - m_widthInvX, z) - center);
            float dBot = Math.Abs(GetInterpolatedHeight(x + m_widthInvX, z) - center);
            float dLeft = Math.Abs(GetInterpolatedHeight(x, z - m_depthInvZ) - center);
            float dRight = Math.Abs(GetInterpolatedHeight(x, z + m_depthInvZ) - center);
            return ((dTop + dBot + dLeft + dRight) / 4f) * 400f;
        }

        /// <summary>
        /// Get the highest point around the edges of the CTSHeightMap - this is used as base level by scanner
        /// </summary>
        /// <returns>Base level</returns>
        public float GetBaseLevel()
        {
            float baseLevel = 0f;

            for (int x = 0; x < m_widthX; x++)
            {
                if (m_heights[x, 0] > baseLevel)
                {
                    baseLevel = m_heights[x, 0];
                }
                if (m_heights[x, m_depthZ-1] > baseLevel)
                {
                    baseLevel = m_heights[x, m_depthZ - 1];
                }
            }

            for (int z = 0; z < m_depthZ; z++)
            {
                if (m_heights[0, z] > baseLevel)
                {
                    baseLevel = m_heights[0, z];
                }
                if (m_heights[m_widthX-1, z] > baseLevel)
                {
                    baseLevel = m_heights[m_widthX - 1, z];
                }
            }

            return baseLevel;
        }

        /// <summary>
        /// Return true if we have data, false otherwise
        /// </summary>
        /// <returns>True if we have data, false otehrwise</returns>
        public bool HasData()
        {
            if (m_widthX <= 0 || m_depthZ <= 0)
            {
                return false;
            }
            if (m_heights == null)
            {
                return false;
            }
            if (m_heights.GetLength(0) != m_widthX || m_heights.GetLength(1) != m_depthZ)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get a specific row
        /// </summary>
        /// <param name="rowX">Row to get</param>
        /// <returns>Content of the row</returns>
        public float[] GetRow(int rowX)
        {
            float [] row = new float[m_depthZ];
            for (int z = 0; z < m_depthZ; z++)
            {
                row[z] = m_heights[rowX, z];
            }
            return row;
        }

        /// <summary>
        /// Set the content of a specific row
        /// </summary>
        /// <param name="rowX">Row to set</param>
        /// <param name="values">Values to set</param>
        public void SetRow(int rowX, float [] values)
        {
            for (int z = 0; z < m_depthZ; z++)
            {
                m_heights[rowX, z] = values[z];
            }
        }

        /// <summary>
        /// Get a specific column
        /// </summary>
        /// <param name="columnZ">Column to get</param>
        /// <returns>Content of the column</returns>
        public float[] GetColumn(int columnZ)
        {
            float[] col = new float[m_widthX];
            for (int x = 0; x < m_widthX; x++)
            {
                col[x] = m_heights[x, columnZ];
            }
            return col;
        }

        /// <summary>
        /// Set the content of a specific column
        /// </summary>
        /// <param name="columnZ">Column to set</param>
        /// <param name="values">Values to set</param>
        public void SetColumn(int columnZ, float[] values)
        {
            for (int x = 0; x< m_widthX; x++)
            {
                m_heights[x, columnZ] = values[x];
            }
        }

        #endregion

        #region Operations

        /// <summary>
        /// Reset the CTSHeightMap including all stats
        /// </summary>
        public void Reset()
        {
            m_widthX = m_depthZ = 0;
            m_widthInvX = m_depthInvZ = 0f;
            m_heights = null;
            m_statMinVal = m_statMaxVal = 0f;
            m_statSumVals = 0;
            m_metaData = new byte[0];
            m_heights = new float[0, 0];
            m_isDirty = false;
        }

        /// <summary>
        /// Update CTSHeightMap stats
        /// </summary>
        public void UpdateStats()
        {
            m_statMinVal = 1f;
            m_statMaxVal = 0f;
            m_statSumVals = 0;
            float height = 0f;
            for (int hmX = 0; hmX < m_widthX; hmX++)
            {
                for (int hmZ = 0; hmZ < m_depthZ; hmZ++)
                {
                    height = m_heights[hmX, hmZ];
                    if (height < m_statMinVal)
                    {
                        m_statMinVal = height;
                    }
                    if (height > m_statMaxVal)
                    {
                        m_statMaxVal = height;
                    }
                    m_statSumVals += height;
                }
            }
        }

        /// <summary>
        /// Smooth the height map
        /// </summary>
        /// <param name="iterations">Number of iterations of smoothing to run</param>
        /// <returns>This</returns>
        public CTSHeightMap Smooth(int iterations)
        {
            for (int i = 0; i < iterations; i++ )
            {
                for (int x = 0; x < m_widthX; x++)
                {
                    for (int z = 0; z < m_depthZ; z++)
                    {
                        m_heights[x, z] = Math_Clamp(0f, 1f, (GetSafeHeight(x - 1, z) + GetSafeHeight(x + 1, z) + GetSafeHeight(x, z - 1) + GetSafeHeight(x, z + 1)) / 4f);
                    }
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Smooth in a given radius
        /// </summary>
        /// <param name="radius">Smoothing radius</param>
        /// <returns>This</returns>
        public CTSHeightMap SmoothRadius(int radius)
        {
            radius = Mathf.Max(5, radius);
            CTSHeightMap filter = new CTSHeightMap(m_widthX, m_depthZ);
            float factor = 1f / ((2 * radius + 1) * (2 * radius + 1));
            for (int y = 0; y < m_depthZ; y++)
            {
                for (int x = 0; x < m_widthX; x++)
                {
                    filter[x, y] = factor * m_heights[x,y];
                }
            }
            for (int x = radius; x < m_widthX - radius; x++)
            {
                int y = radius;
                float sum = 0f;
                for (int i = -radius; i < radius + 1; i++)
                {
                    for (int j = -radius; j < radius + 1; j++)
                    {
                        sum += filter[x + j, y + i];
                    }
                }
                for (y++; y < m_depthZ - radius; y++)
                {
                    for (int j = -radius; j < radius + 1; j++)
                    {
                        sum -= filter[x + j, y - radius - 1];
                        sum += filter[x + j, y + radius];
                    }
                    m_heights[x, y] = sum;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Return a new CTSHeightMap where each point at contains the slopes of this CTSHeightMap at that point
        /// </summary>
        /// <returns></returns>
        public CTSHeightMap GetSlopeMap()
        {
            CTSHeightMap slopeMap = new CTSHeightMap(this);

            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    slopeMap[x, z] = GetSlope(x, z);
                }
            }

            return slopeMap;
        }

        /// <summary>
        /// Copy the source CTSHeightMap
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to copy</param>
        /// <returns>This</returns>
        public CTSHeightMap Copy(CTSHeightMap CTSHeightMap)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not copy different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] = CTSHeightMap.m_heights[x, z];
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Copy the source CTSHeightMap and clamp it
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to copy</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        /// <returns>This</returns>
        public CTSHeightMap CopyClamped(CTSHeightMap CTSHeightMap, float min, float max)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not copy different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = CTSHeightMap.m_heights[x, z];
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Duplicate this CTSHeightMap and return a new onw
        /// </summary>
        /// <returns>A new CTSHeightMap which is a direct duplicate of this one</returns>
        public CTSHeightMap Duplicate()
        {
            return new CTSHeightMap(this);
        }

        /// <summary>
        /// Invert the CTSHeightMap
        /// </summary>
        /// <returns>This</returns>
		public CTSHeightMap Invert()
		{
			for (int x = 0; x < m_widthX; x++)
			{
				for (int z = 0; z < m_depthZ; z++)
				{
					m_heights[x, z] = 1f - m_heights[x, z];
				}
			}
            m_isDirty = true;
		    return this;
		}

        /// <summary>
        /// Flip the CTSHeightMap
        /// </summary>
        /// <returns>This</returns>
        public CTSHeightMap Flip()
        {
            float[,] heights = new float[m_depthZ, m_widthX];
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    heights[z, x] = m_heights[x, z];
                }
            }
            m_heights = heights;
            m_widthX = heights.GetLength(0);
            m_depthZ = heights.GetLength(1);
            m_widthInvX = 1f / (float)(m_widthX);
            m_depthInvZ = 1f / (float)(m_depthZ);
            m_isPowerOf2 = Math_IsPowerOf2(m_widthX) && Math_IsPowerOf2(m_depthZ);
            m_statMinVal = m_statMaxVal = 0f;
            m_statSumVals = 0;
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Normalise the CTSHeightMap
        /// </summary>
        /// <returns>This</returns>
        public CTSHeightMap Normalise()
        {
            float height;
            float maxHeight = float.MinValue;
            float minHeight = float.MaxValue;
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    height = m_heights[x, z];
                    if (height > maxHeight)
                    {
                        maxHeight = height;
                    }
                    if (height < minHeight)
                    {
                        minHeight = height;
                    }
                }
            }
            float heightRange = maxHeight - minHeight;
            if (heightRange > 0f)
            {
                for (int x = 0; x < m_widthX; x++)
                {
                    for (int z = 0; z < m_depthZ; z++)
                    {
                        m_heights[x, z] = (m_heights[x, z] - minHeight) / heightRange;
                    }
                }
                m_isDirty = true;
            }
            return this;
        }

        /// <summary>
        /// Add value
        /// </summary>
        /// <param name="value">Value to add</param>
        public CTSHeightMap Add(float value)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] += value;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Add CTSHeightMap        
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to add</param>
        public CTSHeightMap Add(CTSHeightMap CTSHeightMap)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not add different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] += CTSHeightMap.m_heights[x, z];
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Add value and clamp result
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap AddClamped(float value, float min, float max)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] + value;
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Add CTSHeightMap and clamp result
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to add</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap AddClamped(CTSHeightMap CTSHeightMap, float min, float max)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not add different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] + CTSHeightMap.m_heights[x, z];
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Subtract value
        /// </summary>
        /// <param name="value">Value to subtract</param>
        public CTSHeightMap Subtract(float value)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] -= value;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Subtract CTSHeightMap
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to subtract</param>
        public CTSHeightMap Subtract(CTSHeightMap CTSHeightMap)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not subtract different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] -= CTSHeightMap.m_heights[x, z];
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Subtract value and clamp result
        /// </summary>
        /// <param name="value">Value to subtract</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap SubtractClamped(float value, float min, float max)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] - value;
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Subtract CTSHeightMap and clamp result
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to subtract</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap SubtractClamped(CTSHeightMap CTSHeightMap, float min, float max)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not add different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] - CTSHeightMap.m_heights[x, z];
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Multiply by value
        /// </summary>
        /// <param name="value">Value to multiply</param>
        public CTSHeightMap Multiply(float value)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] *= value;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Multiply by CTSHeightMap
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to multiply</param>
        public CTSHeightMap Multiply(CTSHeightMap CTSHeightMap)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not multiply different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] *= CTSHeightMap.m_heights[x, z];
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Multiply by value and clamp result
        /// </summary>
        /// <param name="value">Value to multiply it by</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap MultiplyClamped(float value, float min, float max)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] * value;
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Multiply by CTSHeightMap and clamp result
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to multiply</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap MultiplyClamped(CTSHeightMap CTSHeightMap, float min, float max)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not multiply different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] * CTSHeightMap.m_heights[x, z];
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Divide by value
        /// </summary>
        /// <param name="value">Value to divide</param>
        public CTSHeightMap Divide(float value)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] /= value;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Divide by CTSHeightMap
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to divide</param>
        public CTSHeightMap Divide(CTSHeightMap CTSHeightMap)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not divide different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] /= CTSHeightMap.m_heights[x, z];
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Divide by value and clamp result
        /// </summary>
        /// <param name="value">Value to divide</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap DivideClamped(float value, float min, float max)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] / value;
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Divide by CTSHeightMap and clamp result
        /// </summary>
        /// <param name="CTSHeightMap">CTSHeightMap to multiply</param>
        /// <param name="min">Min value to clamp it to</param>
        /// <param name="max">Max value to clamp it to</param>
        public CTSHeightMap DivideClamped(CTSHeightMap CTSHeightMap, float min, float max)
        {
            if (m_widthX != CTSHeightMap.m_widthX || m_depthZ != CTSHeightMap.m_depthZ)
            {
                Debug.LogError("Can not divide different sized CTSHeightMap");
                return this;
            }
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    float newValue = m_heights[x, z] / CTSHeightMap.m_heights[x, z];
                    if (newValue < min)
                    {
                        newValue = min;
                    }
                    else if (newValue > max)
                    {
                        newValue = max;
                    }
                    m_heights[x, z] = newValue;
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Sum the content of the CTSHeightMap
        /// </summary>
        /// <returns>Sum of CTSHeightMap content</returns>
        public float Sum()
        {
            float sum = 0f;
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    sum += m_heights[x, z];
                }
            }
            return sum;
        }

        /// <summary>
        /// Average the content of the CTSHeightMap
        /// </summary>
        /// <returns>Average of CTSHeightMap content</returns>
        public float Average()
        {
            return Sum() / (m_widthX * m_depthZ);
        }

        /// <summary>
        /// Adjust to the power of the exponent provided
        /// </summary>
        /// <param name="exponent">Exponent to power of</param>
        public CTSHeightMap Power(float exponent)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] = Mathf.Pow(m_heights[x, z], exponent);
                }
            }
            m_isDirty = true;
            return this;
        }

        /// <summary>
        /// Adjust contrast by the value provided
        /// </summary>
        /// <param name="contrast">Contrast value</param>
        public CTSHeightMap Contrast(float contrast)
        {
            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    m_heights[x, z] = ((m_heights[x, z] - 0.5f) * contrast) + 0.5f;
                }
            }
            m_isDirty = true;
            return this;
        }

        #endregion

        #region Utils

        /// <summary>
        /// Return true if the value is a power of 2
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>True if a power of 2</returns>
        private bool Math_IsPowerOf2(int value)
        {
            return (value & (value - 1)) == 0;
        }

        /// <summary>
        /// Returned value clamped in range of min to max
        /// </summary>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <param name="value">Value to check</param>
        /// <returns>Clamped value</returns>
        private float Math_Clamp(float min, float max, float value)
        {
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        #endregion

        #region Debug

        /// <summary>
        /// A handy utility to dump the content of a CTSHeightMap.
        /// Example: for unity terrain CTSHeightMaps use DumpMap(9f, 0, "", true).
        /// </summary>
        /// <param name="scaleValue">Amount to scale the value by</param>
        /// <param name="precision">The number of decimal points to show</param>
        /// <param name="spacer">The spacer to show (or not)</param>
        /// <param name="flip">Whether or not to flip the lookup</param>
        public void DumpMap(float scaleValue, int precision, string spacer, bool flip)
        {
            StringBuilder debugStr = new StringBuilder();
            string format = "";
            if (precision == 0)
            {
                format = "{0:0}";
            }
            else
            {
                format = "{0:0.";
                for (int p = 0; p < precision; p++)
                {
                    format += "0";
                }
                format += "}";
            }
            if (!string.IsNullOrEmpty(spacer))
            {
                format += spacer;
            }

            for (int x = 0; x < m_widthX; x++)
            {
                for (int z = 0; z < m_depthZ; z++)
                {
                    if (!flip)
                    {
                        debugStr.AppendFormat(format, m_heights[x, z] * scaleValue);
                    }
                    else
                    {
                        debugStr.AppendFormat(format, m_heights[z, x] * scaleValue);
                    }
                }
                debugStr.AppendLine();
            }

            Debug.Log(debugStr.ToString());
        }

        /// <summary>
        /// Dump a specific row
        /// </summary>
        /// <param name="rowX">The row to dump</param>
        /// <param name="scaleValue">Amount to scale the value by</param>
        /// <param name="precision">The number of decimal points to show</param>
        /// <param name="spacer">The spacer to show (or not)</param>
        public void DumpRow(int rowX, float scaleValue, int precision, string spacer)
        {
            StringBuilder debugStr = new StringBuilder();
            string format = "";
            if (precision == 0)
            {
                format = "{0:0}";
            }
            else
            {
                format = "{0:0.";
                for (int p = 0; p < precision; p++)
                {
                    format += "0";
                }
                format += "}";
            }
            if (!string.IsNullOrEmpty(spacer))
            {
                format += spacer;
            }

            float [] values = GetRow(rowX);
            for (int v = 0; v < values.Length; v++)
            {
                debugStr.AppendFormat(format, values[v] * scaleValue);
            }

            Debug.Log(debugStr.ToString());
        }

        /// <summary>
        /// Dump a specific column
        /// </summary>
        /// <param name="columnZ">The column to dump</param>
        /// <param name="scaleValue">Amount to scale the value by</param>
        /// <param name="precision">The number of decimal points to show</param>
        /// <param name="spacer">The spacer to show (or not)</param>
        public void DumpColumn(int columnZ, float scaleValue, int precision, string spacer)
        {
            StringBuilder debugStr = new StringBuilder();
            string format = "";
            if (precision == 0)
            {
                format = "{0:0}";
            }
            else
            {
                format = "{0:0.";
                for (int p = 0; p < precision; p++)
                {
                    format += "0";
                }
                format += "}";
            }
            if (!string.IsNullOrEmpty(spacer))
            {
                format += spacer;
            }

            float[] values = GetColumn(columnZ);
            for (int v = 0; v < values.Length; v++)
            {
                debugStr.AppendFormat(format, values[v] * scaleValue);
            }

            Debug.Log(debugStr.ToString());
        }

        #endregion
    }
}