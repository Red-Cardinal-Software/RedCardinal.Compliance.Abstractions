namespace RedCardinal.Compliance.Abstractions.DataClassification;

/// <summary>
/// Marks a property or field as containing personal data subject to privacy regulations.
/// This is a convenience attribute for GDPR and similar privacy framework compliance.
/// </summary>
/// <example>
/// <code>
/// public class UserProfile
/// {
///     [PersonalData(PersonalDataCategory.Contact)]
///     public string Email { get; set; }
///
///     [PersonalData(PersonalDataCategory.Identity, IsSpecialCategory = true)]
///     public string Ethnicity { get; set; }
/// }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = true)]
public sealed class PersonalDataAttribute : Attribute
{
    /// <summary>
    /// Gets the category of personal data.
    /// </summary>
    public PersonalDataCategory Category { get; }

    /// <summary>
    /// Gets or sets whether this is special category data under GDPR Article 9
    /// (racial/ethnic origin, political opinions, religious beliefs, health data, etc.).
    /// </summary>
    public bool IsSpecialCategory { get; set; }

    /// <summary>
    /// Gets or sets whether consent is required to process this data.
    /// </summary>
    public bool RequiresConsent { get; set; }

    /// <summary>
    /// Gets or sets whether this data is subject to the right to erasure.
    /// </summary>
    public bool SubjectToErasure { get; set; } = true;

    /// <summary>
    /// Gets or sets whether this data is subject to data portability requirements.
    /// </summary>
    public bool SubjectToPortability { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonalDataAttribute"/> class.
    /// </summary>
    /// <param name="category">The category of personal data.</param>
    public PersonalDataAttribute(PersonalDataCategory category)
    {
        Category = category;
    }
}