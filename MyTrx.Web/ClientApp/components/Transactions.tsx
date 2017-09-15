import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';
import { config } from '../config';

interface TransactionDataState {
    transactions: TransactionModel[];
    loading: boolean;
}

export class TransactionData extends React.Component<RouteComponentProps<{}>, TransactionDataState> {
    constructor() {
        super();
        this.state = { transactions: [], loading: true };

        fetch(config.ApiUrl+'transactions')
            .then(response => response.json() as Promise<TransactionModel[]>)
            .then(data => {
                this.setState({ transactions: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : TransactionData.renderTransactionsTable(this.state.transactions);

        return <div>
            <h1>Transactions</h1>
            { contents }
        </div>;
    }

    private static renderTransactionsTable(transactions: TransactionModel[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Flag</th>
                    <th>Account</th>
                    <th>Date</th>
                    <th>Payee</th>
                    <th>Category</th>
                    <th>Note</th>
                    <th>Outflow</th>
                    <th>Inflow</th>
                    <th>Balance</th>
                </tr>
            </thead>
            <tbody>
            {transactions.map(trx =>
                    <tr key={trx.id}>
                        <td><span className={'glyphicon glyphicon-tag flag-'+trx.flagDescription}></span></td>
                        <td>{trx.accountName}</td>
                        <td>{trx.dateFormatted}</td>
                        <td>{trx.payeeName}</td>
                        <td>{trx.categoryName}</td>
                        <td>{trx.note}</td>
                        <td>{trx.outflow}</td>
                        <td>{trx.inflow}</td>
                        <td>{trx.runningBalance}</td>
                        <td><span className={'glyphicon glyphicon-copyright-mark is-' + (trx.cleared ? 'cleared':'uncleared') }></span></td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

interface TransactionModel {
    id: number;
    date: Date;
    dateFormatted: string;
    type: number;
    typeDescription: string
    payeeId: number;
    payeeName: string;
    amount: number;
    accountId: number;
    accountName: string;
    targetAccountId: number;
    targetAccountName: string;
    categoryId: number;
    categoryName: string;
    reference: string;
    cleared: boolean;
    reconciled: boolean;
    flag: number;
    flagDescription: string;
    note: string;
    outflow: number;
    inflow: number;
    runningBalance: number;
}
