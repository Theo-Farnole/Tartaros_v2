using UnityEngine;

namespace PWCommon2
{
    [System.Serializable]
    public class UBrush
    {        
        private int Size
        {
            get
            {
                return m_size;
            }
        }
        [SerializeField] private int m_size;

        [SerializeField] private float[] m_strength;
        [SerializeField] private Texture2D m_brush;
        private const int MIN_BRUSH_SIZE = 3;

        #region Public Creator methods

        /// <summary>
        /// Get a new brush of <paramref name="brushTexture"/> at the given <paramref name="size"/>.
        /// </summary>
        public static UBrush GetBrush(Texture2D brushTexture, int size)
        {
            UBrush brush = new UBrush();
            if (!brush.Load(brushTexture, size))
            {
                Debug.LogWarningFormat("Texture for brush is <b>null</b>.");
            }
            return brush;
        }

        /// <summary>
        /// Get a new <paramref name="size"/> variant of this brush.
        /// </summary>
        public UBrush GetInSize(int size)
        {
            UBrush brush = new UBrush();
            if (!brush.Load(m_brush, size))
            {
                Debug.LogWarningFormat("Texture for brush is <b>null</b>.");
            }
            return brush;
        }

        #endregion

        /// <summary>
        /// Load texture at the given size. Returns false if the texture is null.
        /// </summary>
        /// <returns>Returns false if the texture is null.</returns>
        public bool Load(Texture2D brushTex, int size)
        {
            if ((Object)m_brush == (Object)brushTex && size == m_size && m_strength != null)
            {
                // Nothing to change here.
                return true;
            }

            if ((Object)brushTex != (Object)null)
            {
                float sizeF = (float)size;
                m_size = size;
                m_strength = new float[m_size * m_size];
                if (m_size > 3)
                {
                    for (int index1 = 0; index1 < m_size; ++index1)
                    {
                        for (int index2 = 0; index2 < m_size; ++index2)
                            m_strength[index1 * m_size + index2] = brushTex.GetPixelBilinear(((float)index2 + 0.5f) / sizeF, (float)index1 / sizeF).a;
                    }
                }
                else
                {
                    for (int index = 0; index < m_strength.Length; ++index)
                        m_strength[index] = 1f;
                }
                m_brush = brushTex;
                return true;
            }
            m_strength = new float[1];
            m_strength[0] = 1f;
            m_size = 1;
            return false;
        }

        /// <summary>
        /// Get brush strength at the given coords.
        /// </summary>
        public float GetStrengthAtCoords(int ix, int iy)
        {
            if (ix < 0 || m_size <= ix || iy < 0 || m_size <= iy)
            {
                return 0f;
            }
            return m_strength[iy * m_size + ix];
        }
    }
}
