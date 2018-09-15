using System.Collections.Generic;

namespace API_rest.API.Models
{
    public class Result
    {
        private int code;
        private string messsage;
        private List<Recipe> datas;

        public Result(int code, string messsage, List<Recipe> datas)
        {
            this.code = code;
            this.messsage = messsage;
            this.datas = datas;
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Message
        {
            get { return messsage; }
            set { messsage = value; }
        }

        public List<Recipe> Datas
        {
            get { return datas; }
            set { datas = value; }
        }
    }
}
