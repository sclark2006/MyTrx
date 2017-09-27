import * as React from 'react';
import { SideNavMenu } from './SideNavMenu';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div className='main_container'>
                <div className='col-md-3 left_col'>
                    <div className='left_col scroll-view'>
                        <div className='navbar nav_title'>
                            <a href="index.html" className="site_title">
                                <i className="fa fa-paw"></i>
                            <span>My Trx </span></a>
                        </div>

                        <div className="clearfix"></div>

                        <div className="profile clearfix">
                            <div className="profile_info">
                                <span>Welcome,</span>
                                <h2>John Doe</h2>
                            </div>
                        </div>
                        <br />
                        <SideNavMenu />
                    </div>
                </div>
                <div className='right_col' role='main'>
                    {this.props.children}
                </div>
            </div>;
    }
}
