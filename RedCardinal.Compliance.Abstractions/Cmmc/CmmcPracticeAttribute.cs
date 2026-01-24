namespace RedCardinal.Compliance.Abstractions.Cmmc;

/// <summary>
/// Marks code as implementing or supporting a CMMC practice.
/// </summary>
/// <remarks>
/// CMMC 2.0 has three levels:
/// <list type="bullet">
/// <item><description>Level 1 - Foundational (15 practices from FAR 52.204-21)</description></item>
/// <item><description>Level 2 - Advanced (110 practices aligned with NIST SP 800-171)</description></item>
/// <item><description>Level 3 - Expert (134 practices (110 from NIST SP 800-171 + 24 from NIST SP 800-172))</description></item>
/// </list>
/// Practices are organized by domains (e.g., AC for Access Control, SC for System and Communications Protection).
/// </remarks>
/// <example>
/// <code>
/// [CmmcPractice("AC.L2-3.1.1", Level = CmmcLevel.Level2, Domain = CmmcDomain.AccessControl)]
/// public class AccessControlService { }
///
/// [CmmcPractice("SC.L2-3.13.11", Description = "CUI encryption at rest")]
/// public void EncryptControlledUnclassifiedInfo() { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class CmmcPracticeAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.Cmmc;

    /// <summary>
    /// Gets or sets the CMMC level.
    /// </summary>
    public CmmcLevel? Level { get; set; }

    /// <summary>
    /// Gets or sets the CMMC domain.
    /// </summary>
    public CmmcDomain? Domain { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CmmcPracticeAttribute"/> class.
    /// </summary>
    /// <param name="practiceId">
    /// The CMMC practice identifier (e.g., "AC.L2-3.1.1", "SC.L2-3.13.11").
    /// </param>
    public CmmcPracticeAttribute(string practiceId) : base(practiceId)
    {
    }
}