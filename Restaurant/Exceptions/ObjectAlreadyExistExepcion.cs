namespace Exceptions
{
    public class ObjectAlreadyExistExepcion : Exception
    {
        public ObjectAlreadyExistExepcion(string objName) : base(objName) { }
    }
}
