namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Documents evidence of compliance control implementation.
/// Use this to provide auditors with justification for how code satisfies requirements.
/// </summary>
/// <example>
/// <code>
/// [ComplianceEvidence(
///     EvidenceType.Implementation,
///     "Password hashing uses bcrypt with cost factor 12",
///     RelatedControls = new[] { "CC6.1", "A.8.5" })]
/// public string HashPassword(string password) { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class ComplianceEvidenceAttribute : Attribute
{
    /// <summary>
    /// Gets the type of evidence being documented.
    /// </summary>
    public EvidenceType Type { get; }

    /// <summary>
    /// Gets the description of the evidence.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets or sets the control IDs this evidence supports.
    /// </summary>
    public string[]? RelatedControls { get; set; }

    /// <summary>
    /// Gets or sets a reference to external documentation (URL, document ID, etc.).
    /// </summary>
    public string? DocumentationReference { get; set; }

    /// <summary>
    /// Gets or sets the date this evidence was last verified.
    /// Format: ISO 8601 (YYYY-MM-DD).
    /// </summary>
    public string? LastVerifiedDate { get; set; }

    /// <summary>
    /// Gets or sets who verified this evidence.
    /// </summary>
    public string? VerifiedBy { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplianceEvidenceAttribute"/> class.
    /// </summary>
    /// <param name="type">The type of evidence.</param>
    /// <param name="description">Description of the evidence.</param>
    public ComplianceEvidenceAttribute(EvidenceType type, string description)
    {
        Type = type;
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }
}