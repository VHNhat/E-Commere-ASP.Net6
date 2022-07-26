namespace E_Commerce.Utility
{
    public class ResponseEntity
    {
        private string message;
        private Object response;

        public ResponseEntity(string message, object response)
        {
            this.message = message;
            this.response = response;
        }

        public ResponseEntity(string message) {
            this.message = message;
        }

        public string Message { get => message; set => message = value; }
        public object Response { get => response; set => response = value; }
    }
}
