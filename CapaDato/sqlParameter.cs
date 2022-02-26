using System.Data;

namespace CapaDato
{
    internal class sqlParameter
    {
        private string v1;
        private SqlDbType varChar;
        private int v2;

        public sqlParameter(string v1, SqlDbType varChar, int v2)
        {
            this.v1 = v1;
            this.varChar = varChar;
            this.v2 = v2;
        }

        public object Value { get; internal set; }
    }
}