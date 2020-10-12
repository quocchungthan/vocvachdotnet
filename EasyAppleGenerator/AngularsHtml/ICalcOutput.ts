export interface ICalcOutput {
  innerHTML?: Array<ICalcOutput>;
  type: "container" | "text" | "select" | "array" | "datePicker" | 'dateTimePicker' | 'checkBox' | 'numberInput';
  label?: string;
  row?: number;
  size?: number;
  offset?: number;
  name: string;
}
