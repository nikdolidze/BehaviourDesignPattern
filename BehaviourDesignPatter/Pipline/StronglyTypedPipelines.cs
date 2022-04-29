using Pipline.StronglyTypedPipelines;

namespace Pipline
{
    public class BasicPipeline : Pipeline<int, float>
    {
        public BasicPipeline()
        {
            PipelineSteps = input => input
                .Step(new DoubleStep())
                .Step(new ToStringStep())
                .Step(new DuplicateStep())
                .Step(new ToFloatStep());
        }
    }

    public class InnerPipeline : Pipeline<int, int>
    {
        public InnerPipeline()
        {
            PipelineSteps = input => input
                .Step(new ThirdStep())
                .Step(new RoundStep());
        }
    }

    public class NestedPipeline : Pipeline<int, string>
    {
        public NestedPipeline()
        {
            PipelineSteps = input => input
            .Step(new DoubleStep())
            .Step(new InnerPipeline())
            .Step(new ToStringStep());
        }
    }

    public class BranchingPipeline : Pipeline<int, string>
    {
        public BranchingPipeline()
        {
            PipelineSteps = input => input
            .Step(new OptionalStep<int, int>(
                    f => f > 50,
                    new InnerPipeline()
                ))
            .Step(new ChoiceStep<int, int>(
                    f => f > 100,
                    new HalfStep(),
                    new DoubleStep()
                ))
            .Step(new ToStringStep());
        }
    }
}