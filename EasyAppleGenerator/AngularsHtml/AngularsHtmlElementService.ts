import createHtmlElement = require("create-html-element");

/**
 * 
 *
input DocumentDistributionInputType {
  id: ID = null
  """not null"""
  schoolId: String = null
  senderId: String!
  status: DocumentDistributionStatus = null
  title: String = null
  recipients: [DocumentDistributionRecipientInputType] = null
  printedDocumentId: ID = null
  openCrxPrintedDocumentId: String = null
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
  emailId: String = null
  journalEntryId: String = null
  originalRecipientId: String = null
  recipientId: String!
  channels: [DocumentDistributionRecipientChannel] = null
  role: DocumentDistributionRecipientRole = null
  attachedDocumentId: ID = null
  openCrxAttachedDocumentId: String = null
}

enum DocumentDistributionRecipientRole {
  OriginalRecipient
  Parent
  AdditionalApprenticeshipTrainer
  ResponsibleApprenticeshipTrainer
}
 */
class AngularsHtmlElementService {
    public createInputTextForm() {
        return createHtmlElement({
            name: 'input',
            attributes: {
                class: 'pt-1 pb-1',
                "[input]": "{{input}}",
                "output": "() => {}",
                "*ifDirective": true
            },
            html: "ecec"
        })
    }
}

export const angularHtmlElementService = new AngularsHtmlElementService();