import createHtmlElement = require("create-html-element");
import { create } from "domain";

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
  public initHtmlPage(content: string): string {
    var css = createHtmlElement({
      name: "link",
      attributes: {
        rel: "stylesheet",
        href: "style.css",
      },
    });
    var bootstrap = createHtmlElement({
      name: "link",
      attributes: {
        rel: "stylesheet",
        href:
          "https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css",
        integrity:
          "sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z",
        crossorigin: "anonymous",
      },
    });
    var meta1 = createHtmlElement({
      name: "meta",
      attributes: {
        charset: "UTF-8",
      },
    });
    var metal2 = createHtmlElement({
      name: "meta",
      attributes: {
        name: "viewport",
        content: "width=device-width, initial-scale=1.0",
      },
    });
    var title = createHtmlElement({
      name: "title",
      html: "GeneratedPage",
    });
    var body = createHtmlElement({
      name: "body",
      html: "\n" + content + "\n",
    });
    var head = createHtmlElement({
      name: "head",
      html: "\n" + [meta1, metal2, title, bootstrap, css].join("\n") + "\n",
    });
    return createHtmlElement({
      name: "html",
      attributes: {
        lang: "en",
      },
      html: "\n" + [head, body].join("\n") + "\n",
    });
  }

  public createInputTextForm() {
    return createHtmlElement({
      name: "input",
      attributes: {
        class: "pt-1 pb-1",
        "[input]": "{{input}}",
        output: "() => {}",
        "*ifDirective": true,
      },
      html: "ecec",
    });
  }
}

export const angularHtmlElementService = new AngularsHtmlElementService();
