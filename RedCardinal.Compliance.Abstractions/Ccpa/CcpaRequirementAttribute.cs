namespace RedCardinal.Compliance.Abstractions.Ccpa;

/// <summary>
/// Marks code as implementing or supporting a CCPA requirement.
/// </summary>
/// <remarks>
/// Key CCPA consumer rights:
/// <list type="bullet">
/// <item><description>Right to know what personal information is collected</description></item>
/// <item><description>Right to delete personal information</description></item>
/// <item><description>Right to opt-out of sale of personal information</description></item>
/// <item><description>Right to non-discrimination</description></item>
/// <item><description>Right to correct inaccurate personal information (CPRA)</description></item>
/// <item><description>Right to limit use of sensitive personal information (CPRA)</description></item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// [CcpaRequirement("1798.100", Right = CcpaRight.RightToKnow)]
/// public PersonalInfoReport GetConsumerData(string consumerId) { }
///
/// [CcpaRequirement("1798.105", Right = CcpaRight.RightToDelete)]
/// public async Task DeleteConsumerDataAsync(string consumerId) { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class CcpaRequirementAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.Ccpa;

    /// <summary>
    /// Gets or sets the consumer right this implementation supports.
    /// </summary>
    public CcpaRight? Right { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CcpaRequirementAttribute"/> class.
    /// </summary>
    /// <param name="sectionId">
    /// The California Civil Code section (e.g., "1798.100", "1798.105").
    /// </param>
    public CcpaRequirementAttribute(string sectionId) : base(sectionId)
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="CcpaRequirementAttribute"/> class.
    /// </summary>
    /// <param name="sectionId">
    /// The California Civil Code section (e.g., "1798.100", "1798.105").
    /// </param>
    /// <param name="right">
    /// The consumer right this implementation supports.
    /// </param>
    public CcpaRequirementAttribute(string sectionId, CcpaRight right) : base(sectionId)
    {
        Right = right;
    }
}