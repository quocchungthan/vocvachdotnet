import createHtmlElement = require("create-html-element");

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