namespace Exceptions
{
    public class ObjectNotExist : Exception
    {
        public ObjectNotExist(string objName) : base(objName)
        {

        }
    }
}