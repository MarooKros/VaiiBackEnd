using Ganss.Xss;

namespace VaibackEnd.Services
{
    /// <summary>
    /// Interface for user message sanitizer.
    /// </summary>
    public interface IHTMLSanitizer
    {
        /// <summary>
        /// Sanitizes the input message.
        /// </summary>
        /// <param name="message">The message to sanitize.</param>

        string Sanitize(string message);
    }
    /// <summary>
    /// Implementation of <see cref="HTMLSanitizer"/>.
    /// </summary>
    public class HtmlMessageSanitizer : HtmlSanitizer, IHTMLSanitizer
    {
        private readonly HtmlSanitizer _htmlSanitizer;
        /// <summary>
        /// Constructor.
        /// </summary>
        public HtmlMessageSanitizer()
        {
            _htmlSanitizer = new HtmlSanitizer();
            _htmlSanitizer.AllowedAttributes.Add("style");
            _htmlSanitizer.AllowedAttributes.Add("class");
            _htmlSanitizer.AllowedAttributes.Add("src");
            _htmlSanitizer.AllowedCssProperties.Add("color");
            _htmlSanitizer.AllowedCssProperties.Add("background-color");
            _htmlSanitizer.AllowedTags.Add("span");
            _htmlSanitizer.AllowedTags.Add("div");
            _htmlSanitizer.AllowedTags.Add("p");
            _htmlSanitizer.AllowedTags.Add("a");
            _htmlSanitizer.AllowedTags.Add("b");
            _htmlSanitizer.AllowedTags.Add("i");
            _htmlSanitizer.AllowedTags.Add("u");
            _htmlSanitizer.AllowedTags.Add("ul");
            _htmlSanitizer.AllowedTags.Add("ol");
            _htmlSanitizer.AllowedTags.Add("li");
            _htmlSanitizer.AllowedTags.Add("br");
            _htmlSanitizer.AllowedTags.Add("hr");
            _htmlSanitizer.AllowedTags.Add("img");
            _htmlSanitizer.AllowedTags.Add("table");
            _htmlSanitizer.AllowedTags.Add("thead");
            _htmlSanitizer.AllowedTags.Add("tbody");
            _htmlSanitizer.AllowedTags.Add("tfoot");
            _htmlSanitizer.AllowedTags.Add("tr");
            _htmlSanitizer.AllowedTags.Add("th");
            _htmlSanitizer.AllowedTags.Add("td");
            _htmlSanitizer.AllowedTags.Add("h1");
            _htmlSanitizer.AllowedTags.Add("h2");
            _htmlSanitizer.AllowedTags.Add("h3");
            _htmlSanitizer.AllowedTags.Add("h4");
            _htmlSanitizer.AllowedTags.Add("h5");
            _htmlSanitizer.AllowedTags.Add("h6");
            _htmlSanitizer.AllowedTags.Add("strong");
            _htmlSanitizer.AllowedTags.Add("em");
            _htmlSanitizer.AllowedTags.Add("blockquote");
            _htmlSanitizer.AllowedTags.Add("pre");
            _htmlSanitizer.AllowedTags.Add("code");
            _htmlSanitizer.AllowedTags.Add("sub");
            _htmlSanitizer.AllowedTags.Add("sup");

            _htmlSanitizer.AllowedAttributes.Remove("href");
            _htmlSanitizer.AllowedAttributes.Remove("target");
        }
        /// <inheritdoc />

        public string Sanitize(string message)
        {
            return _htmlSanitizer.Sanitize(message);
        }
    }
}
