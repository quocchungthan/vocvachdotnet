import { ContainerElement } from "./ContainerElement";
import { ICalcOutput } from "./ICalcOutput";

const sampleInput = `
  input DocumentDistributionInputType {
    id: ID = null
    """not null"""
    schoolId: String = null
    senderId: String!
    status: DocumentDistributionStatus = null
    title: String = null
    recipients: [DocumentDistributionRecipientInputType] = null
    mainRecipient: DocumentDistributionRecipientInputType]= null
    printedDocumentId: ID = null
    emailTemplateId: String = null
  }
  enum DocumentDistributionStatus {
    New
    InProgress
    Complete
  }
  enum DocumentDistributionRecipientChannel {
    Peax
    Email
    Print
  }
  
  input DocumentDistributionRecipientInputType {
    """Place holder 1"""
    emailId: String = null
    """Place holder 1"""
    journalEntryId: String = null
    """Place holder 1"""
    originalRecipientId: String = null
    """Place holder 1"""
    recipientId: String!
    """Place holder 1"""
    channels: [DocumentDistributionRecipientChannel] = null
    """Place holder 1"""
    role: DocumentDistributionRecipientRole = null
    """Place holder 1"""
    attachedDocumentId: ID = null
    """Place holder 1"""
  }
  
  enum DocumentDistributionRecipientRole {
    OriginalRecipient
    Parent
    AdditionalApprenticeshipTrainer
    ResponsibleApprenticeshipTrainer
  }`;

class CalculationService {
  public seperatedCalculation(schema: string = sampleInput) {
    return new ContainerElement(schema, null, "Generated Form");
  }
}

export const calculatingService = new CalculationService();
