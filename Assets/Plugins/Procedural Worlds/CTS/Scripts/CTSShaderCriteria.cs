
using System.Collections.Generic;

namespace CTS
{
    /// <summary>
    /// Serves as a multi-dimensional key to lookup shader name strings from a dictionary.
    /// </summary>
    public struct CTSShaderCriteria
    {
        public readonly CTSConstants.EnvironmentRenderer renderPipelineType;
        public readonly CTSConstants.ShaderType shaderType;
        public readonly CTSConstants.ShaderFeatureSet shaderFeatureSet;
        public CTSShaderCriteria(CTSConstants.EnvironmentRenderer p1, CTSConstants.ShaderType p2, CTSConstants.ShaderFeatureSet p3)
        {
            renderPipelineType = p1;
            shaderType = p2;
            shaderFeatureSet = p3;
        }
    }
}
