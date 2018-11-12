import { Transaction } from './transaction';

export interface Account {
  name: string;
  number: string;
  transactions: Array<Transaction>;
}
