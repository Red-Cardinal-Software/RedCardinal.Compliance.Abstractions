namespace RedCardinal.Compliance.Abstractions.Gdpr;

/// <summary>
/// Marks code as implementing or supporting a GDPR article requirement.
/// </summary>
/// <remarks>
/// Common GDPR articles for technical implementation (not exhaustive):
/// <list type="bullet">
/// <item><description>Article 5 - Principles relating to processing of personal data</description></item>
/// <item><description>Article 6 - Lawfulness of processing</description></item>
/// <item><description>Article 7 - Conditions for consent</description></item>
/// <item><description>Article 15 - Right of access</description></item>
/// <item><description>Article 16 - Right to rectification</description></item>
/// <item><description>Article 17 - Right to erasure</description></item>
/// <item><description>Article 20 - Right to data portability</description></item>
/// <item><description>Article 21 - Right to object</description></item>
/// <item><description>Article 22 - Automated decision-making</description></item>
/// <item><description>Article 25 - Data protection by design and default</description></item>
/// <item><description>Article 32 - Security of processing</description></item>
/// <item><description>Article 33 - Notification of data breach</description></item>
/// </list>
/// Any valid article number (1-99) may be used.
/// </remarks>
/// <example>
/// <code>
/// [GdprArticle("17", Description = "Implements right to erasure")]
/// public async Task DeleteUserDataAsync(string userId) { }
///
/// [GdprArticle("32", Principle = GdprPrinciple.SecurityOfProcessing)]
/// public void EncryptPersonalData() { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class GdprArticleAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.Gdpr;

    /// <summary>
    /// Gets or sets the GDPR principle this implementation supports.
    /// </summary>
    public GdprPrinciple? Principle { get; set; }

    /// <summary>
    /// Gets or sets the specific paragraph within the article (e.g., "1", "2(a)").
    /// </summary>
    public string? Paragraph { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GdprArticleAttribute"/> class.
    /// </summary>
    /// <param name="articleNumber">
    /// The GDPR article number (e.g., "17", "25", "32").
    /// </param>
    public GdprArticleAttribute(string articleNumber) : base(articleNumber)
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="GdprArticleAttribute"/> class.
    /// </summary>
    /// <param name="articleNumber">
    /// The GDPR article number (e.g., "17", "25", "32").
    /// </param>
    /// <param name="principle">
    /// The GDPR principle this implementation supports.
    /// </param>
    public GdprArticleAttribute(string articleNumber, GdprPrinciple principle) : base(articleNumber)
    {
        Principle = principle;
    }
}