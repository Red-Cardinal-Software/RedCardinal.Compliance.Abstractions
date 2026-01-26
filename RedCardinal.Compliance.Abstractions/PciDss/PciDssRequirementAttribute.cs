namespace RedCardinal.Compliance.Abstractions.PciDss;

/// <summary>
/// Marks code as implementing or supporting a PCI DSS requirement.
/// </summary>
/// <remarks>
/// PCI DSS v4.0 requirements are organized into 12 main requirements:
/// <list type="bullet">
/// <item><description>1 - Install and maintain network security controls</description></item>
/// <item><description>2 - Apply secure configurations</description></item>
/// <item><description>3 - Protect stored account data</description></item>
/// <item><description>4 - Protect cardholder data during transmission</description></item>
/// <item><description>5 - Protect against malicious software</description></item>
/// <item><description>6 - Develop and maintain secure systems</description></item>
/// <item><description>7 - Restrict access to cardholder data</description></item>
/// <item><description>8 - Identify users and authenticate access</description></item>
/// <item><description>9 - Restrict physical access to cardholder data</description></item>
/// <item><description>10 - Log and monitor access</description></item>
/// <item><description>11 - Test security of systems regularly</description></item>
/// <item><description>12 - Support information security with policies</description></item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// [PciDssRequirement("3.5.1", Description = "Encrypts stored cardholder data")]
/// public class CardDataEncryptionService { }
///
/// [PciDssRequirement("8.3.1", Goal = PciDssGoal.AccessControl)]
/// public void AuthenticateUser() { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class PciDssRequirementAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.PciDss;

    /// <summary>
    /// Gets or sets the PCI DSS goal this requirement belongs to.
    /// </summary>
    public PciDssGoal? Goal { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PciDssRequirementAttribute"/> class.
    /// </summary>
    /// <param name="requirementId">
    /// The PCI DSS requirement identifier (e.g., "3.5.1", "8.3.1", "10.2.1").
    /// </param>
    public PciDssRequirementAttribute(string requirementId) : base(requirementId)
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="PciDssRequirementAttribute"/> class with a specific goal.
    /// </summary>
    /// <param name="requirementId">
    /// The PCI DSS requirement identifier (e.g., "3.5.1", "8.3.1", "10.2.1").
    /// </param>
    /// <param name="goal">
    /// The PCI DSS goal this requirement belongs to.
    /// </param>
    public PciDssRequirementAttribute(string requirementId, PciDssGoal goal) : this(requirementId)
    {
        Goal = goal;
    }
}