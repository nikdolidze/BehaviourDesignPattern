using Pipline.StronglyTypedPipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviouPattern
{
    public abstract class BasePipelineStep<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
    {
        public event Action<INPUT> OnInput;
        public event Action<OUTPUT> OnOutput;

        // note need for descendant types to implement this, not Process()
        protected abstract OUTPUT ProcessStep(INPUT input);

        public OUTPUT Process(INPUT input)
        {
            OnInput?.Invoke(input);

            var output = ProcessStep(input);

            OnOutput?.Invoke(output);

            return output;
        }
    }
    public class EventStep<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT>
    {
        public event Action<INPUT> OnInput;
        public event Action<OUTPUT> OnOutput;

        private IPipelineStep<INPUT, OUTPUT> _innerStep;

        public EventStep(IPipelineStep<INPUT, OUTPUT> innerStep)
        {
            _innerStep = innerStep;
        }

        public OUTPUT Process(INPUT input)
        {
            OnInput?.Invoke(input);

            var output = _innerStep.Process(input);

            OnOutput?.Invoke(output);

            return output;
        }
    }
    public static class PipelineStepEventExtensions
    {
        public static OUTPUT Step<INPUT, OUTPUT>(this INPUT input, IPipelineStep<INPUT, OUTPUT> step, Action<INPUT> inputEvent = null, Action<OUTPUT> outputEvent = null)
        {
            if (inputEvent != null || outputEvent != null)
            {
                var eventDecorator = new EventStep<INPUT, OUTPUT>(step);
                eventDecorator.OnInput += inputEvent;
                eventDecorator.OnOutput += outputEvent;

                return eventDecorator.Process(input);
            }

            return step.Process(input);
        }
    }
}
