import createHtmlElement = require("create-html-element");
import { create } from "domain";
import { EnumSelect } from "./EnumSelect";
import { ICalcOutput } from "./ICalcOutput";
import { TextElement } from "./TextElement";

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

  public build(model: ICalcOutput): string {
    if (model instanceof TextElement) {
      return this.buildTextElement(model);
    }
    if (model instanceof EnumSelect) {
      return this.buildEnumSelect(model);
    }

    return "";
  }

  private buildEnumSelect(model: EnumSelect): string {
    const optionKeys = Object.keys(model.options);
    const options = optionKeys.map((k) => {
      return createHtmlElement({
        name: "option",
        attributes: {
          value: k,
        },
        html: model.options[k],
      });
    });

    const input = createHtmlElement({
      name: "select",
      html: "\n" + options.join("\n") + "\n",
    });

    const label = createHtmlElement({
      name: "label",
      html: model.label,
    });

    return createHtmlElement({
      name: "div",
      attributes: {
        class: "pt-2",
      },
      html: "\n" + label + "\n" + input + "\n",
    });
  }

  private buildTextElement(model: TextElement): string {
    const input = createHtmlElement({
      name: "input",
    });
    const label = createHtmlElement({
      name: "label",
      html: model.label,
    });

    return createHtmlElement({
      name: "div",
      attributes: {
        class: "pt-2",
      },
      html: "\n" + label + "\n" + input + "\n",
    });
  }

  public createSuperContainer(inner: string): string {
    var col12 = createHtmlElement({
      name: "div",
      attributes: {
        class: "col-12",
      },
      html: inner,
    });
    var row = createHtmlElement({
      name: "div",
      attributes: {
        class: "row",
      },
      html: "\n" + col12 + "\n",
    });
    return createHtmlElement({
      name: "div",
      attributes: {
        class: "container",
      },
      html: "\n" + row + "\n",
    });
  }
}

export const angularHtmlElementService = new AngularsHtmlElementService();
