import { ICalcOutput } from "../AngularsHtml/ICalcOutput";
import { exec } from "child_process";
import { configService } from "../Configurations/ConfigService";
import * as path from "path";
import { fileWritingService } from "../FileIO/FileWritingService";
import createHtmlElement = require("create-html-element");
import { ArrayContainerElement } from "../AngularsHtml/ArrayContainerElement";
import { ContainerElement } from "../AngularsHtml/ContainerElement";
import { DataSelectElement } from "../AngularsHtml/DataSelect";
import { EnumSelect } from "../AngularsHtml/EnumSelect";
import { TextElement } from "../AngularsHtml/TextElement";

export interface IHtmlGenerator {
  generateComponentAsync(model: ICalcOutput): Promise<number>;
  build(model: ICalcOutput): string;
  buildContainerElement(model: ContainerElement): string;
  buildArrayContainerElement(model: ArrayContainerElement): string;
  buildEnumSelect(model: EnumSelect): string;
  buildDataSelectElement(model: DataSelectElement): string;
  buildTextElement(model: TextElement): string;
  createSuperContainer(inner: string): string;
}

class AngularGenerator implements IHtmlGenerator {
  public generateComponentAsync(model: ICalcOutput): Promise<number> {
    const pathx = configService.Config.typechan.projectDir;
    const module = configService.Config.typechan.module;
    return new Promise<number>((resolve, reject) => {
      exec(
        `cd ${pathx} && ng g c ${module}/ui/${model.name} --module=${module} --export`,
        async (e, out, err) => {
          const angularFileName = this.toDash(model.name);
          const htmlFile = path.join(
            pathx,
            this.htmlPath(out) ||
              `src/app/${module}/ui/${angularFileName}/${angularFileName}.component.html`
          );
          await fileWritingService.forceWriteFileWithAbsolutePath(
            htmlFile,
            this.createSectionElement(
              model.name,
              this.build(model) + this.submitButton("")
            )
          );
          //   console.log(htmlFile);
          if (e) {
            reject(err);
          } else {
            resolve(0);
          }
        }
      );
    });
  }

  private createSectionElement(title: string, content: string): string {
    return createHtmlElement({
      name: "app-section",
      attributes: {
        title,
      },
      html: content,
    });
  }

  private submitButton(formName) {
    return createHtmlElement({
      name: "div",
      attributes: {
        class: "pt-2 pb-2",
      },
      html: createHtmlElement({
        name: "app-button",
        attributes: {
          label: "Submit " + formName,
          variant: "success",
        },
      }),
    });
  }

  private toDash(str: string): string {
    const namePattern = /([A-Z]+[a-z]*)$/g;
    let name = str;
    const words = [];

    while (name.match(/[A-Z]/)) {
      words.push(namePattern.exec(name)[1]);
      name = name.replace(namePattern, "");
    }

    return [...words, name]
      .filter((x) => x)
      .reverse()
      .join("-")
      .toLocaleLowerCase();
  }

  /**
   *
   * should create interface
   *
   *
   *
   */

  // these building methods should be interfaces, implementation will be located in specific projects
  public build(model: ICalcOutput): string {
    if (model instanceof TextElement) {
      return this.buildTextElement(model);
    }
    if (model instanceof EnumSelect) {
      return this.buildEnumSelect(model);
    }
    if (model instanceof DataSelectElement) {
      return this.buildDataSelectElement(model);
    }
    if (model instanceof ContainerElement) {
      return this.buildContainerElement(model);
    }
    if (model instanceof ArrayContainerElement) {
      return this.buildArrayContainerElement(model);
    }

    return "";
  }

  public buildContainerElement(model: ContainerElement): string {
    const label = createHtmlElement({
      name: "h4",
      html: model.label,
    });
    const objects = model.innerHTML
      .map((x) => {
        if (
          x instanceof ArrayContainerElement ||
          x instanceof ContainerElement
        ) {
          return null;
        }
        return this.build(x);
      })
      .filter((x) => x);
    const objectContainers = model.innerHTML
      .map((x) => {
        if (
          x instanceof ArrayContainerElement ||
          x instanceof ContainerElement
        ) {
          return this.build(x);
        }
        return null;
      })
      .filter((x) => x);

    return createHtmlElement({
      name: "div",
      attributes: {
        class: "mt-1",
      },
      html:
        createHtmlElement({ name: "hr" }) +
        (model.label ? "\n" + label : "") +
        "\n" +
        createHtmlElement({
          name: "div",
          attributes: {
            class: "row",
          },
          html: objects.join("\n"),
        }) +
        "\n" +
        objectContainers +
        "\n",
    });
  }

  public buildArrayContainerElement(model: ArrayContainerElement): string {
    const input = createHtmlElement({
      name: "div",
      attributes: {
        class: "pt-2 pb-2",
      },
      html: createHtmlElement({
        name: "app-button",
        attributes: {
          label: model.label + "+",
        },
      }),
    });
    let object = this.build(model.innerHTML[0]);

    if (
      !(
        model.innerHTML[0] instanceof ContainerElement ||
        model.innerHTML[0] instanceof ArrayContainerElement
      )
    ) {
      object = createHtmlElement({
        name: "div",
        attributes: {
          class: "row",
        },
        html: object,
      });
    }

    return createHtmlElement({
      name: "div",
      attributes: {
        class: "",
      },
      html: "\n" + object + "\n" + input + "\n",
    });
  }

  public buildEnumSelect(model: EnumSelect): string {
    const optionKeys = Object.keys(model.options);
    const options = optionKeys.map((k) => ({
      key: k,
      value: model.options[k],
    }));

    const input = createHtmlElement({
      name: "app-select",
      attributes: {
        label: model.label,
        options: JSON.stringify(options),
      },
    });

    return createHtmlElement({
      name: "div",
      attributes: {
        class: "col-" + model.size,
      },
      html: "\n" + input + "\n",
    });
  }

  public buildDataSelectElement(model: DataSelectElement): string {
    const input = createHtmlElement({
      name: "div",
      html: createHtmlElement({
        name: "app-button",
        attributes: {
          label: "Search object",
        },
      }),
    });
    const label = createHtmlElement({
      name: "label",
      attributes: {
        class: "slds-form-element__label",
      },
      html: model.label,
    });

    return createHtmlElement({
      name: "div",
      attributes: {
        class: "col-3 slds-m-top--large",
      },
      // html: "\n" + input" + "\n",
      html: "\n" + label + "\n" + input + "\n",
    });
  }

  public buildTextElement(model: TextElement): string {
    const wrapper = createHtmlElement({
      name: "app-text-input",
      attributes: {
        label: model.label,
      },
    });
    return createHtmlElement({
      name: "div",
      attributes: {
        class: "col-" + model.size,
      },
      html: "\n" + wrapper + "\n",
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

  /**end */

  private htmlPath(out: string): string {
    const htmlPathPattern = /(src.*\.html)/;
    return htmlPathPattern.exec(out)?.[1];
  }
}

export const angularGenerator = new AngularGenerator();
