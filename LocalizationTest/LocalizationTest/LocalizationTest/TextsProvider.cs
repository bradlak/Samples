using LocalizationTest.Resources;

namespace LocalizationTest
{
    public class TextsProvider
    {
        public string GetText(string key)
        {
            return TextResources.ResourceManager.GetString(key);
        }
    }
}

