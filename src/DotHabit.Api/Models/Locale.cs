namespace DotQuiz.Api.Models
{
    public class Locale 
    {
        public string Language { get; private set; }
        public string Territory { get; private set; }
        public string Name => ToString();

        public Locale(string language, string territory)
        {
            this.Language = language;
            this.Territory = territory;
        }

        public override string ToString() 
        {
            return $"{this.Language}_{this.Territory}";
        }
    }
}