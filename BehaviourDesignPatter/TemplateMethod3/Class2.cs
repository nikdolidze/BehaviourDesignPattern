
/*
You have a procces wher you may need to  create some cind of object you are going to use in function and you need to change that object
it is possible to provide  it as a parameter will talk a little bit about that regarding composition and inheritance but in this case we choose to call it an abstract class
we can provide default implementation here however in this example we do not we then have  again have three variatoins where the factory method is going to craete us a 
different object hopefully this is pretty self-explanatory not much to say here and now kind of talk a little bit about theese methods that are essentially
 */
namespace TemplateMethod3not2
{
    public abstract class Procces
    {
        public void Start()
        {
            var word = FactoryMethod();
        }
        protected abstract string FactoryMethod();
    }

    public class Variation1 : Procces
    {
        protected override string FactoryMethod()
        {
            return "FactoryMethod variation1";
        }
    }
    public class Variation2 : Procces
    {
        protected override string FactoryMethod()
        {
            return "FactoryMethod variation2";
        }
    }

}
