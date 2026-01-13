namespace RedCardinal.Compliance.Abstractions.Sox;

/// <summary>
/// Marks code as implementing or supporting a SOX IT control.
/// </summary>
/// <remarks>
/// SOX Section 404 requires internal controls over financial reporting (ICFR).
/// IT General Controls (ITGCs) typically cover:
/// <list type="bullet">
/// <item><description>Access to Programs and Data</description></item>
/// <item><description>Program Changes</description></item>
/// <item><description>Program Development</description></item>
/// <item><description>Computer Operations</description></item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// [SoxControl("ITGC-AC-01", Category = SoxControlCategory.AccessControl)]
/// public class FinancialSystemAccessControl { }
///
/// [SoxControl("ITGC-CM-03", Description = "Change approval workflow")]
/// public void ApproveChange(ChangeRequest request) { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class SoxControlAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.Sox;

    /// <summary>
    /// Gets or sets the SOX control category.
    /// </summary>
    public SoxControlCategory? Category { get; set; }

    /// <summary>
    /// Gets or sets the control type.
    /// </summary>
    public SoxControlType ControlType { get; set; } = SoxControlType.Itgc;

    /// <summary>
    /// Gets or sets the relevant SOX section (e.g., "302", "404").
    /// </summary>
    public string? Section { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SoxControlAttribute"/> class.
    /// </summary>
    /// <param name="controlId">
    /// The control identifier (e.g., "ITGC-AC-01", "APP-01").
    /// </param>
    public SoxControlAttribute(string controlId) : base(controlId)
    {
    }
}