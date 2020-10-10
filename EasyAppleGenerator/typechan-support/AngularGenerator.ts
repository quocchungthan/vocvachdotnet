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

class AngularGenerator {
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
            this.build(model)
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

  private buildContainerElement(model: ContainerElement): string {
    const label = createHtmlElement({
      name: "h4",
      html: model.label,
    });
    const objects = model.innerHTML.map((x) => this.build(x));

    return createHtmlElement({
      name: "div",
      html:
        "\n" +
        label +
        "\n" +
        createHtmlElement({
          name: "div",
          attributes: {
            class: "row",
          },
          html: objects.join("\n"),
        }) +
        "\n",
    });
  }

  private buildArrayContainerElement(model: ArrayContainerElement): string {
    const input = createHtmlElement({
      name: "button",
      html: "One more line",
    });
    const label = createHtmlElement({
      name: "label",
      html: model.label,
    });
    const object = this.build(model.innerHTML[0]);

    return createHtmlElement({
      name: "div",
      attributes: {
        class: "pt-2",
      },
      html: "\n" + label + "\n" + object + "\n" + input + "\n",
    });
  }

  /**
   * 
   * 
   * <div class="slds-grid slds-grid_pull-padded slds-grid_vertical-align-center slds-m-top_large">
  <div class="slds-col_padded">
    <ngl-select label="Select Label" fieldLevelHelpTooltip="Some helpful information" [error]="hasError ? error : null">
      <select ngl [required]="required" [disabled]="disabled">
        <option value="">Please select</option>
        <option>Option One</option>
        <option>Option Two</option>
        <option>Option Three</option>
      </select>
    </ngl-select>
  </div>
</div>
   */

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
      attributes: {
        ngl: true,
      },
      html: "\n" + options.join("\n") + "\n",
    });

    const nglSelect = createHtmlElement({
      name: "ngl-select",
      attributes: {
        label: model.label,
        fieldLevelHelpTooltip: "Some helpful information",
      },
      html: "\n" + input + "\n",
    });

    const innerdiv = createHtmlElement({
      name: "div",
      attributes: {
        class: "slds-col_padded",
      },
      html: "\n" + nglSelect + "\n",
    });

    const wrapper = createHtmlElement({
      name: "div",
      attributes: {
        class:
          "slds-grid slds-grid_pull-padded slds-grid_vertical-align-center slds-m-top_large",
      },
      html: "\n" + innerdiv + "\n",
    });
    return createHtmlElement({
      name: "div",
      attributes: {
        class: "col-" + model.size,
      },
      html: "\n" + wrapper + "\n",
    });
  }

  private buildDataSelectElement(model: DataSelectElement): string {
    const input = createHtmlElement({
      name: "button",
      html: "Search object",
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

  /**
   * 
   * <div class="slds-col_padded">
      <ngl-input label="Input Label" fieldLevelHelpTooltip="Some helpful information" [error]="hasError ? error : null">
        <input ngl type="input" [required]="required" [disabled]="disabled" placeholder="Placeholder Text">
      </ngl-input>
    </div>
   */
  private buildTextElement(model: TextElement): string {
    const input = createHtmlElement({
      name: "input",
      attributes: {
        ngl: true,
        type: "input",
        placeHolder: "Placeholder Text",
      },
    });
    const label = createHtmlElement({
      name: "ngl-input",
      attributes: {
        label: model.label,
        fieldLevelHelpTooltip: "Some helpful information",
      },
      html: "\n" + input + "\n",
    });

    const innerdiv = createHtmlElement({
      name: "div",
      attributes: {
        class: "slds-col_padded",
      },
      html: "\n" + label + "\n",
    });

    const wrapper = createHtmlElement({
      name: "div",
      attributes: {
        class:
          "slds-grid slds-grid_pull-padded slds-grid_vertical-align-center slds-m-top_large",
      },
      html: "\n" + innerdiv + "\n",
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
