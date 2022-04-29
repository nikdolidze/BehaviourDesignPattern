using Pipline.StronglyTypedPipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipline
{
    public class DoubleStep : IPipelineStep<int, int>
    {
        public int Process(int input)
        {
            return input * 2;
        }
    }

    public class HalfStep : IPipelineStep<int, int>
    {
        public int Process(int input)
        {
            return input / 2;
        }
    }

    public class ThirdStep : IPipelineStep<int, float>
    {
        public float Process(int input)
        {
            return input / 3f;
        }
    }

    public class RoundStep : IPipelineStep<float, int>
    {
        public int Process(float input)
        {
            return (int)input;
        }
    }

    public class ToStringStep : IPipelineStep<int, string>
    {
        public string Process(int input)
        {
            return input.ToString();
        }
    }

    public class DuplicateStep : IPipelineStep<string, string>
    {
        public string Process(string input)
        {
            return input + "." + input;
        }
    }

    public class ToFloatStep : IPipelineStep<string, float>
    {
        public float Process(string input)
        {
            return float.Parse(input);
        }
    }
}
