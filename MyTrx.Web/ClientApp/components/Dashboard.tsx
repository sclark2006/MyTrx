import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Dashboard extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        //top tiles 
        return <div className="row tile_count">
            <div className="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <span className="count_top"><i className="fa fa-user"></i> Total Users</span>
                <div className="count">2500</div>
                <span className="count_bottom"><i className="green">4% </i> From last Week</span>
            </div>

        </div>;
    }
}
