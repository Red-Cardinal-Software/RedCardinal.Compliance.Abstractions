namespace RedCardinal.Compliance.Abstractions.NistCsf;

/// <summary>
/// NIST Cybersecurity Framework 2.0 core functions.
/// </summary>
public enum NistCsfFunction
{
    /// <summary>
    /// Govern (GV) - Establish and monitor cybersecurity risk management strategy.
    /// New in CSF 2.0. Covers organizational context, risk management strategy,
    /// roles and responsibilities, policies, and oversight.
    /// </summary>
    Govern,

    /// <summary>
    /// Identify (ID) - Understand organizational context and cybersecurity risks.
    /// Covers asset management, business environment, governance, risk assessment,
    /// and supply chain risk management.
    /// </summary>
    Identify,

    /// <summary>
    /// Protect (PR) - Implement safeguards for critical services.
    /// Covers identity management, access control, awareness training,
    /// data security, platform security, and technology infrastructure resilience.
    /// </summary>
    Protect,

    /// <summary>
    /// Detect (DE) - Identify cybersecurity events.
    /// Covers continuous monitoring and adverse event analysis.
    /// </summary>
    Detect,

    /// <summary>
    /// Respond (RS) - Take action regarding detected incidents.
    /// Covers incident management, analysis, mitigation, reporting, and communication.
    /// </summary>
    Respond,

    /// <summary>
    /// Recover (RC) - Restore capabilities after incidents.
    /// Covers recovery planning and execution.
    /// </summary>
    Recover
}