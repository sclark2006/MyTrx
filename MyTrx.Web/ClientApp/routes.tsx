import * as React from 'react';
import { Route } from 'react-router-dom';
import { Dashboard} from './components/Dashboard';
import { Layout } from './components/Layout';
import { Budget } from './components/Budget';
import { TransactionData } from './components/Transactions';

export const routes = <Layout>
    <Route exact path='/' component={Dashboard} />
    <Route path='/dashboard' component={Dashboard} />
    <Route path='/budget' component={Budget} />
    <Route path='/transactions' component={TransactionData} />
</Layout>;
