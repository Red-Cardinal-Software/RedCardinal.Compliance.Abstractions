namespace RedCardinal.Compliance.Abstractions.Sox;

/// <summary>
/// Types of SOX controls.
/// </summary>
public enum SoxControlType
{
    /// <summary>
    /// IT General Control - foundational controls supporting application controls.
    /// </summary>
    Itgc,

    /// <summary>
    /// Application Control - automated controls within business applications.
    /// </summary>
    ApplicationControl,

    /// <summary>
    /// IT Dependent Manual Control - manual control that relies on IT.
    /// </summary>
    ItDependentManual,

    /// <summary>
    /// Entity Level Control - controls at the organizational level.
    /// </summary>
    EntityLevel
}