import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { TransactionData } from './components/Transactions';
import { Counter } from './components/Counter';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/transactions' component={TransactionData} />
</Layout>;
