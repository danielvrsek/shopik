namespace Entity.Tools
{
    internal class IdentityGenerator
    {
        private int identifier = -1;

        public int GetNextId()
        {
            return identifier--;
        }
    }
}
