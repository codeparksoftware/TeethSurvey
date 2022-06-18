using TeetSurvey.Repository.Model;

namespace Sample
{
    public class SingleService
    {
        private static SingleService _service;
        private SingleService() { }

        public static SingleService Instance
        {
            get
            {
                if (_service == null) { _service = new SingleService(); }
                return _service;
            }
        }

        public Survey Survey { get; set; }
    }
}
