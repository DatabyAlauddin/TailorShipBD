namespace TylorShop.Models_Customs
{
    public class FieldTranslationService
    {
        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>
    {
        { "Home", "হোম" },
        { "About", "সম্পর্কে" },
        { "Contact", "যোগাযোগ" },
        { "Welcome", "স্বাগতম" },
        { "FooterText", "পাদটীকা টেক্সট" },

        { "Amount", "পরিমাণ" },
        { "Discount", "ছাড়" },
        { "Due", "বাকি" }
    };

        public string Translate(string key)
        {
            return _translations.ContainsKey(key) ? _translations[key] : key;
        }
    }

}
