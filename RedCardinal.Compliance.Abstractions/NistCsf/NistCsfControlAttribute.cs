namespace RedCardinal.Compliance.Abstractions.NistCsf;

/// <summary>
/// Marks code as implementing or supporting a NIST Cybersecurity Framework control.
/// </summary>
/// <remarks>
/// NIST CSF 2.0 is organized into six core functions:
/// <list type="bullet">
/// <item><description>Govern (GV) - Organizational context and risk management</description></item>
/// <item><description>Identify (ID) - Asset and risk identification</description></item>
/// <item><description>Protect (PR) - Safeguards implementation</description></item>
/// <item><description>Detect (DE) - Anomaly and event detection</description></item>
/// <item><description>Respond (RS) - Incident response</description></item>
/// <item><description>Recover (RC) - Recovery planning and improvements</description></item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// [NistCsfControl("PR.AC-1", Function = NistCsfFunction.Protect)]
/// public class IdentityManagementService { }
///
/// [NistCsfControl("DE.CM-1", Description = "Network monitoring implementation")]
/// public void MonitorNetworkTraffic() { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class NistCsfControlAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.NistCsf;

    /// <summary>
    /// Gets or sets the NIST CSF core function.
    /// </summary>
    public NistCsfFunction? Function { get; set; }

    /// <summary>
    /// Gets or sets the category within the function.
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// Gets or sets the implementation tier (1-4).
    /// </summary>
    public int? Tier { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="NistCsfControlAttribute"/> class.
    /// </summary>
    /// <param name="controlId">
    /// The NIST CSF control identifier (e.g., "PR.AC-1", "DE.CM-1", "ID.AM-1").
    /// </param>
    public NistCsfControlAttribute(string controlId) : base(controlId)
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="NistCsfControlAttribute"/> class with a specific function.
    /// </summary>
    /// <param name="controlId">The NIST CSF control identifier.</param>
    /// <param name="function">The NIST CSF core function.</param>
    public NistCsfControlAttribute(string controlId, NistCsfFunction function) : base(controlId)
    {
        Function = function;
    }
}