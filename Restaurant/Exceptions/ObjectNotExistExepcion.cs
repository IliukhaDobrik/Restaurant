namespace Exceptions
{
    public class ObjectNotExistExepcion : Exception
    {
        public ObjectNotExistExepcion(string objName) : base(objName)
        {

        }
    }
}