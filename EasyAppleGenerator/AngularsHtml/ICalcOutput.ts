export interface ICalcOutput {
  innerHTML?: Array<ICalcOutput>;
  type: "container" | "text" | "select" | "array";
  label?: string;
  row?: number;
  size?: number;
  offset?: number;
}
