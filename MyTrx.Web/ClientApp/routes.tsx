import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Budget } from './components/Budget';
import { TransactionData } from './components/Transactions';

export const routes = <Layout>
    <Route exact path='/' component={Budget} />
    <Route path='/budget' component={Budget} />
    <Route path='/transactions' component={TransactionData} />
</Layout>;
