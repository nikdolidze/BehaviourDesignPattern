using System;

namespace Pipline
{
    namespace StronglyTypedPipelines
    {
        public interface IPipelineStep<INPUT, OUTPUT>
        {
            OUTPUT Process(INPUT input);
        }
        public static class PipelineStepExtensions
        {
            public static OUTPUT Step<INPUT, OUTPUT>(this INPUT input, IPipelineStep<INPUT, OUTPUT> step)
            {
                return step.Process(input);
            }
        }
        public abstract class Pipeline<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
        {
            public Func<INPUT, OUTPUT> PipelineSteps { get; protected set; }

            public OUTPUT Process(INPUT input)
            {
                return PipelineSteps(input);
            }
        }

    }
}