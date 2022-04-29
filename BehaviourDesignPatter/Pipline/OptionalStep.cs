using Pipline.StronglyTypedPipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipline
{
    public class OptionalStep<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT> where INPUT : OUTPUT
    {
        private IPipelineStep<INPUT, OUTPUT> _step;
        private Func<INPUT, bool> _choice;

        public OptionalStep(Func<INPUT, bool> choice, IPipelineStep<INPUT, OUTPUT> step)
        {
            _choice = choice;
            _step = step;
        }

        public OUTPUT Process(INPUT input)
        {
            if (_choice(input))
            {
                return _step.Process(input);
            }
            else
            {
                return input;
            }
        }
    }

    public class ChoiceStep<INPUT, OUTPUT> : IPipelineStep<INPUT, OUTPUT> where INPUT : OUTPUT
    {
        private IPipelineStep<INPUT, OUTPUT> _first;
        private IPipelineStep<INPUT, OUTPUT> _second;
        private Func<INPUT, bool> _choice;

        public ChoiceStep(Func<INPUT, bool> choice, IPipelineStep<INPUT, OUTPUT> first, IPipelineStep<INPUT, OUTPUT> second)
        {
            _choice = choice;
            _first = first;
            _second = second;
        }

        public OUTPUT Process(INPUT input)
        {
            if (_choice(input))
            {
                return _first.Process(input);
            }
            else
            {
                return _second.Process(input);
            }
        }
    }
}
