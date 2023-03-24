namespace TestProject.Models {
    public class Brand_Car {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }

        public virtual ICollection<Model_Car>? models { get; set; }
    }
}
