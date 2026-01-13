namespace RedCardinal.Compliance.Abstractions.DataClassification;

/// <summary>
/// Categories of personal data for privacy compliance.
/// </summary>
public enum PersonalDataCategory
{
    /// <summary>
    /// Identity data (name, username, ID numbers).
    /// </summary>
    Identity,

    /// <summary>
    /// Contact information (email, phone, address).
    /// </summary>
    Contact,

    /// <summary>
    /// Financial data (bank accounts, payment info).
    /// </summary>
    Financial,

    /// <summary>
    /// Transaction data (purchases, payments).
    /// </summary>
    Transaction,

    /// <summary>
    /// Technical data (IP address, device info, cookies).
    /// </summary>
    Technical,

    /// <summary>
    /// Profile data (preferences, interests).
    /// </summary>
    Profile,

    /// <summary>
    /// Usage data (how services are used).
    /// </summary>
    Usage,

    /// <summary>
    /// Marketing and communications preferences.
    /// </summary>
    Marketing,

    /// <summary>
    /// Location data (GPS, address history).
    /// </summary>
    Location,

    /// <summary>
    /// Biometric data (fingerprints, facial recognition).
    /// </summary>
    Biometric,

    /// <summary>
    /// Health data.
    /// </summary>
    Health,

    /// <summary>
    /// Genetic data.
    /// </summary>
    Genetic,

    /// <summary>
    /// Political opinions.
    /// </summary>
    Political,

    /// <summary>
    /// Religious or philosophical beliefs.
    /// </summary>
    Religious,

    /// <summary>
    /// Trade union membership.
    /// </summary>
    TradeUnion,

    /// <summary>
    /// Sexual orientation or sex life.
    /// </summary>
    SexualOrientation,

    /// <summary>
    /// Criminal convictions or offences.
    /// </summary>
    Criminal
}