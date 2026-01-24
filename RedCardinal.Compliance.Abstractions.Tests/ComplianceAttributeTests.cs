using System.Reflection;
using RedCardinal.Compliance.Abstractions;
using RedCardinal.Compliance.Abstractions.Soc2;
using RedCardinal.Compliance.Abstractions.Iso27001;
using RedCardinal.Compliance.Abstractions.Gdpr;
using RedCardinal.Compliance.Abstractions.PciDss;
using RedCardinal.Compliance.Abstractions.Hipaa;
using RedCardinal.Compliance.Abstractions.Ccpa;
using RedCardinal.Compliance.Abstractions.Cmmc;
using RedCardinal.Compliance.Abstractions.Sox;
using RedCardinal.Compliance.Abstractions.NistCsf;
using RedCardinal.Compliance.Abstractions.DataClassification;
using RedCardinal.Compliance.Abstractions.Evidence;

namespace RedCardinal.Compliance.Abstractions.Tests;

public class ComplianceAttributeTests
{
    [Fact]
    public void Soc2ControlAttribute_SetsPropertiesCorrectly()
    {
        var attr = new Soc2ControlAttribute("CC6.1")
        {
            Description = "Access control implementation",
            Category = Soc2Category.Security,
            Status = ImplementationStatus.Implemented,
            Owner = "Security Team"
        };

        Assert.Equal("CC6.1", attr.ControlId);
        Assert.Equal(ComplianceFramework.Soc2, attr.Framework);
        Assert.Equal("Access control implementation", attr.Description);
        Assert.Equal(Soc2Category.Security, attr.Category);
        Assert.Equal(ImplementationStatus.Implemented, attr.Status);
        Assert.Equal("Security Team", attr.Owner);
    }

    [Fact]
    public void Iso27001ControlAttribute_SetsPropertiesCorrectly()
    {
        var attr = new Iso27001ControlAttribute("A.8.24")
        {
            Description = "Cryptography control",
            Theme = Iso27001Theme.Technological
        };

        Assert.Equal("A.8.24", attr.ControlId);
        Assert.Equal(ComplianceFramework.Iso27001, attr.Framework);
        Assert.Equal(Iso27001Theme.Technological, attr.Theme);
    }

    [Fact]
    public void GdprArticleAttribute_SetsPropertiesCorrectly()
    {
        var attr = new GdprArticleAttribute("17")
        {
            Description = "Right to erasure implementation",
            Principle = GdprPrinciple.StorageLimitation,
            Paragraph = "1"
        };

        Assert.Equal("17", attr.ControlId);
        Assert.Equal(ComplianceFramework.Gdpr, attr.Framework);
        Assert.Equal(GdprPrinciple.StorageLimitation, attr.Principle);
        Assert.Equal("1", attr.Paragraph);
    }

    [Fact]
    public void PciDssRequirementAttribute_SetsPropertiesCorrectly()
    {
        var attr = new PciDssRequirementAttribute("3.5.1")
        {
            Description = "Encryption of stored cardholder data",
            Goal = PciDssGoal.ProtectAccountData
        };

        Assert.Equal("3.5.1", attr.ControlId);
        Assert.Equal(ComplianceFramework.PciDss, attr.Framework);
        Assert.Equal(PciDssGoal.ProtectAccountData, attr.Goal);
    }

    [Fact]
    public void DataClassificationAttribute_SetsPropertiesCorrectly()
    {
        var attr = new DataClassificationAttribute(DataSensitivity.Pii, "User email addresses")
        {
            RequiresEncryptionAtRest = true,
            RequiresEncryptionInTransit = true,
            RetentionDays = 365
        };

        Assert.Equal(DataSensitivity.Pii, attr.Sensitivity);
        Assert.Equal("User email addresses", attr.Description);
        Assert.True(attr.RequiresEncryptionAtRest);
        Assert.True(attr.RequiresEncryptionInTransit);
        Assert.Equal(365, attr.RetentionDays);
    }

    [Fact]
    public void PersonalDataAttribute_SetsPropertiesCorrectly()
    {
        var attr = new PersonalDataAttribute(PersonalDataCategory.Health)
        {
            IsSpecialCategory = true,
            RequiresConsent = true,
            SubjectToErasure = true,
            SubjectToPortability = true
        };

        Assert.Equal(PersonalDataCategory.Health, attr.Category);
        Assert.True(attr.IsSpecialCategory);
        Assert.True(attr.RequiresConsent);
        Assert.True(attr.SubjectToErasure);
        Assert.True(attr.SubjectToPortability);
    }

    [Fact]
    public void ComplianceEvidenceAttribute_SetsPropertiesCorrectly()
    {
        var attr = new ComplianceEvidenceAttribute(EvidenceType.Encryption, "Uses AES-256-GCM")
        {
            RelatedControls = new[] { "CC6.1", "A.8.24" },
            DocumentationReference = "SEC-001",
            VerifiedBy = "Security Auditor"
        };

        Assert.Equal(EvidenceType.Encryption, attr.Type);
        Assert.Equal("Uses AES-256-GCM", attr.Description);
        Assert.Equal(new[] { "CC6.1", "A.8.24" }, attr.RelatedControls);
        Assert.Equal("SEC-001", attr.DocumentationReference);
    }

    [Fact]
    public void ComplianceJustificationAttribute_SetsPropertiesCorrectly()
    {
        var attr = new ComplianceJustificationAttribute("PCI-DSS 3.5.1", "Exceeds requirement with AES-256", JustificationType.ExceedsRequirement)
        {
            ApprovedBy = "CISO",
            ApprovalDate = "2024-01-15"
        };

        Assert.Equal("PCI-DSS 3.5.1", attr.ControlReference);
        Assert.Equal("Exceeds requirement with AES-256", attr.Justification);
        Assert.Equal(JustificationType.ExceedsRequirement, attr.Type);
        Assert.Equal("CISO", attr.ApprovedBy);
    }

    [Fact]
    public void AuditNoteAttribute_SetsPropertiesCorrectly()
    {
        var attr = new AuditNoteAttribute("Session timeout configured per policy")
        {
            Priority = AuditPriority.Important,
            Author = "Security Team"
        };

        Assert.Equal("Session timeout configured per policy", attr.Note);
        Assert.Equal(AuditPriority.Important, attr.Priority);
        Assert.Equal("Security Team", attr.Author);
    }

    [Fact]
    public void ComplianceAttributes_AllowMultiple()
    {
        var attrUsage = typeof(Soc2ControlAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.NotNull(attrUsage);
        Assert.True(attrUsage.AllowMultiple);
    }

    [Fact]
    public void ComplianceAttributes_AreInherited()
    {
        var attrUsage = typeof(Soc2ControlAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.NotNull(attrUsage);
        Assert.True(attrUsage.Inherited);
    }

    [Fact]
    public void HipaaControlAttribute_SetsPropertiesCorrectly()
    {
        var attr = new HipaaControlAttribute("164.312(a)(1)")
        {
            Description = "Access control implementation",
            Safeguard = HipaaSafeguard.Technical,
            RequirementType = HipaaRequirementType.Required
        };

        Assert.Equal("164.312(a)(1)", attr.ControlId);
        Assert.Equal(ComplianceFramework.Hipaa, attr.Framework);
        Assert.Equal(HipaaSafeguard.Technical, attr.Safeguard);
        Assert.Equal(HipaaRequirementType.Required, attr.RequirementType);
    }

    [Fact]
    public void CcpaRequirementAttribute_SetsPropertiesCorrectly()
    {
        var attr = new CcpaRequirementAttribute("1798.105")
        {
            Description = "Right to delete implementation",
            Right = CcpaRight.RightToDelete
        };

        Assert.Equal("1798.105", attr.ControlId);
        Assert.Equal(ComplianceFramework.Ccpa, attr.Framework);
        Assert.Equal(CcpaRight.RightToDelete, attr.Right);
    }

    [Fact]
    public void CmmcPracticeAttribute_SetsPropertiesCorrectly()
    {
        var attr = new CmmcPracticeAttribute("AC.L2-3.1.1")
        {
            Description = "Limit system access",
            Level = CmmcLevel.Level2,
            Domain = CmmcDomain.AccessControl
        };

        Assert.Equal("AC.L2-3.1.1", attr.ControlId);
        Assert.Equal(ComplianceFramework.Cmmc, attr.Framework);
        Assert.Equal(CmmcLevel.Level2, attr.Level);
        Assert.Equal(CmmcDomain.AccessControl, attr.Domain);
    }

    [Fact]
    public void SoxControlAttribute_SetsPropertiesCorrectly()
    {
        var attr = new SoxControlAttribute("ITGC-AC-01")
        {
            Description = "Access control for financial systems",
            Category = SoxControlCategory.AccessControl,
            ControlType = SoxControlType.Itgc,
            Section = "404"
        };

        Assert.Equal("ITGC-AC-01", attr.ControlId);
        Assert.Equal(ComplianceFramework.Sox, attr.Framework);
        Assert.Equal(SoxControlCategory.AccessControl, attr.Category);
        Assert.Equal(SoxControlType.Itgc, attr.ControlType);
        Assert.Equal("404", attr.Section);
    }

    [Fact]
    public void NistCsfControlAttribute_SetsPropertiesCorrectly()
    {
        var attr = new NistCsfControlAttribute("PR.AC-1")
        {
            Description = "Identity management",
            Function = NistCsfFunction.Protect,
            Category = "Access Control",
            Tier = 3
        };

        Assert.Equal("PR.AC-1", attr.ControlId);
        Assert.Equal(ComplianceFramework.NistCsf, attr.Framework);
        Assert.Equal(NistCsfFunction.Protect, attr.Function);
        Assert.Equal("Access Control", attr.Category);
        Assert.Equal(3, attr.Tier);
    }

    #region IComplianceProbe and ComplianceProbeResult Tests

    [Fact]
    public void ComplianceProbeResult_Success_CreatesCompliantResult()
    {
        var evidence = new Dictionary<string, object> { { "checksum", "abc123" } };
        var result = ComplianceProbeResult.Success("All checks passed", evidence);

        Assert.True(result.IsCompliant);
        Assert.Equal("All checks passed", result.Message);
        Assert.NotNull(result.Evidence);
        Assert.Equal("abc123", result.Evidence["checksum"]);
        Assert.Null(result.Severity);
        Assert.True(result.Timestamp <= DateTimeOffset.UtcNow);
    }

    [Fact]
    public void ComplianceProbeResult_Failure_CreatesNonCompliantResult()
    {
        var result = ComplianceProbeResult.Failure("Ledger tampered", ProbeSeverity.Critical);

        Assert.False(result.IsCompliant);
        Assert.Equal("Ledger tampered", result.Message);
        Assert.Equal(ProbeSeverity.Critical, result.Severity);
    }

    [Fact]
    public void ComplianceProbeResult_Constructor_SetsAllProperties()
    {
        var evidence = new Dictionary<string, object> { { "key", "value" } };
        var result = new ComplianceProbeResult(
            isCompliant: false,
            message: "Test failure",
            evidence: evidence,
            severity: ProbeSeverity.High);

        Assert.False(result.IsCompliant);
        Assert.Equal("Test failure", result.Message);
        Assert.Equal(ProbeSeverity.High, result.Severity);
        Assert.NotNull(result.Evidence);
    }

    [Fact]
    public void ProbeSeverity_HasExpectedValues()
    {
        Assert.Equal(0, (int)ProbeSeverity.Info);
        Assert.Equal(1, (int)ProbeSeverity.Low);
        Assert.Equal(2, (int)ProbeSeverity.Medium);
        Assert.Equal(3, (int)ProbeSeverity.High);
        Assert.Equal(4, (int)ProbeSeverity.Critical);
    }

    #endregion

    #region IEvidenceProvider and EvidenceRecord Tests

    [Fact]
    public void EvidenceRecord_Constructor_SetsRequiredProperties()
    {
        var record = new EvidenceRecord("provider-1", "Test evidence");

        Assert.Equal("provider-1", record.ProviderId);
        Assert.Equal("Test evidence", record.Description);
        Assert.True(record.Timestamp <= DateTimeOffset.UtcNow);
        Assert.Null(record.Hash);
        Assert.Null(record.HashAlgorithm);
    }

    [Fact]
    public void EvidenceRecord_Constructor_SetsHashAndAlgorithm()
    {
        var record = new EvidenceRecord(
            providerId: "provider-1",
            description: "Hashed evidence",
            hash: "abc123def456",
            hashAlgorithm: "SHA-384");

        Assert.Equal("abc123def456", record.Hash);
        Assert.Equal("SHA-384", record.HashAlgorithm);
    }

    [Fact]
    public void EvidenceRecord_DefaultsHashAlgorithmToSha256_WhenHashProvided()
    {
        var record = new EvidenceRecord(
            providerId: "provider-1",
            description: "Hashed evidence",
            hash: "abc123");

        Assert.Equal("SHA-256", record.HashAlgorithm);
    }

    [Fact]
    public void EvidenceRecord_OscalFields_CanBeSet()
    {
        var subjectUuid = Guid.NewGuid();
        var componentUuid = Guid.NewGuid();
        var observationUuid = Guid.NewGuid();

        var record = new EvidenceRecord("provider-1", "OSCAL evidence")
        {
            SubjectUuid = subjectUuid,
            ComponentUuid = componentUuid,
            ObservationUuid = observationUuid,
            ObservationMethod = "TEST",
            OscalEvidenceType = "collected"
        };

        Assert.Equal(subjectUuid, record.SubjectUuid);
        Assert.Equal(componentUuid, record.ComponentUuid);
        Assert.Equal(observationUuid, record.ObservationUuid);
        Assert.Equal("TEST", record.ObservationMethod);
        Assert.Equal("collected", record.OscalEvidenceType);
    }

    [Fact]
    public void EvidenceRecord_Metadata_CanBeProvided()
    {
        var metadata = new Dictionary<string, string>
        {
            { "oscal-prop-name", "rotation-date" },
            { "oscal-prop-value", "2024-01-15" }
        };

        var record = new EvidenceRecord(
            providerId: "key-rotation",
            description: "Key rotation evidence",
            metadata: metadata);

        Assert.NotNull(record.Metadata);
        Assert.Equal("rotation-date", record.Metadata["oscal-prop-name"]);
    }

    [Fact]
    public void EvidenceRecord_RawData_CanBeSet()
    {
        var rawData = new byte[] { 0x01, 0x02, 0x03 };
        var record = new EvidenceRecord("provider-1", "Binary evidence")
        {
            RawData = rawData
        };

        Assert.Equal(rawData, record.RawData);
    }

    [Fact]
    public void EvidenceRecord_ThrowsOnNullProviderId()
    {
        Assert.Throws<ArgumentNullException>(() => new EvidenceRecord(null!, "description"));
    }

    [Fact]
    public void EvidenceRecord_ThrowsOnNullDescription()
    {
        Assert.Throws<ArgumentNullException>(() => new EvidenceRecord("provider-1", null!));
    }

    #endregion
}