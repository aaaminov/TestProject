namespace TestProject.Models {
    public class Model_Car {
        public int id { get; set; }
        public int brand_id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }

        public virtual Brand_Car brand { get; set; }
    }
}
