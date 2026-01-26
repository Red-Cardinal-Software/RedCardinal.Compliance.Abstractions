namespace RedCardinal.Compliance.Abstractions.Hipaa;

/// <summary>
/// Marks code as implementing or supporting a HIPAA Security Rule safeguard.
/// </summary>
/// <remarks>
/// HIPAA Security Rule standards (45 CFR Part 164, Subpart C):
/// <list type="bullet">
/// <item><description>Administrative Safeguards (§164.308)</description></item>
/// <item><description>Physical Safeguards (§164.310)</description></item>
/// <item><description>Technical Safeguards (§164.312)</description></item>
/// <item><description>Organizational Requirements (§164.314)</description></item>
/// <item><description>Policies and Procedures (§164.316)</description></item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// [HipaaControl("164.312(a)(1)", Description = "Access control implementation")]
/// public class PhiAccessControl { }
///
/// [HipaaControl("164.312(e)(1)", Safeguard = HipaaSafeguard.Technical)]
/// public void EncryptPhiInTransit() { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class HipaaControlAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.Hipaa;

    /// <summary>
    /// Gets or sets the safeguard category.
    /// </summary>
    public HipaaSafeguard? Safeguard { get; set; }

    /// <summary>
    /// Gets or sets whether this is a required or addressable implementation specification.
    /// </summary>
    public HipaaRequirementType RequirementType { get; set; } = HipaaRequirementType.Required;

    /// <summary>
    /// Initializes a new instance of the <see cref="HipaaControlAttribute"/> class.
    /// </summary>
    /// <param name="controlId">
    /// The HIPAA control identifier (e.g., "164.312(a)(1)", "164.308(a)(1)(ii)(D)").
    /// </param>
    public HipaaControlAttribute(string controlId) : base(controlId)
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="HipaaControlAttribute"/> class and sets the safeguard category.
    /// </summary>
    /// <param name="controlId">
    /// The HIPAA control identifier (e.g., "164.312(a)(1)", "164.308(a)(1)(ii)(D)").
    /// </param>
    /// <param name="safeguard">
    /// The safeguard category.
    /// </param>
    public HipaaControlAttribute(string controlId, HipaaSafeguard safeguard) : base(controlId)
    {
        Safeguard = safeguard;
    }
}