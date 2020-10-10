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
  public seperatedCalculation(schema: string = sampleInput): ICalcOutput[] {
    // many entries in one schema and we should consider by Mutation, not type dependency
    return this.findEntriesInputSchema(schema).map(
      (v, i) => new ContainerElement(schema, v, "Generated Form " + i)
    );
  }

  // Cloned from Container Element
  private findEntriesInputSchema(schema: string): string[] {
    const pattern = /input (\w+) \{/gi;
    const formPattern = /input \w+ \{([^{}]+)\}/gi;
    const inputNames = this.collectMatchs(schema, pattern);
    const inputForms = this.collectMatchs(schema, formPattern);
    // It's business
    return inputNames.filter(
      (name) => !inputForms.find((form) => form.includes(name))
    );
  }

  private collectMatchs(input: string, pattern: RegExp): string[] {
    return input.match(pattern)?.map((x) => x.replace(pattern, "$1"));
  }
}

export const calculatingService = new CalculationService();
