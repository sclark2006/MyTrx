import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class SideNavMenu extends React.Component<{}, {}> {
    public render() {
        return <div id="sidebar-menu" className="main_menu_side hidden-print main_menu">
            <div className="menu_section">
                <h3>General</h3>
                <ul className="nav side-menu">
                    <li>
                        <NavLink to={'/'} exact activeClassName='active'>
                            <i className="fa fa-home"></i> Dashboard 
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/budget'} activeClassName='active'>
                            <i className="fa fa-home"></i> Budget
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/transactions'} activeClassName='active'>
                            <i className="fa fa-home"></i> All Accounts
                        </NavLink>
                    </li>
                    <li><a><i className="fa fa-edit"></i> Budget <span className="fa fa-chevron-down"></span></a>
                        <ul className="nav child_menu">
                            <li><NavLink to={'/account1'} activeClassName='active'>Account 1 </NavLink></li>
                            <li><NavLink to={'/account2'} activeClassName='active'>Account 2 </NavLink></li>
                        </ul>
                    </li>
                    <li><a><i className="fa fa-edit"></i> Tracking <span className="fa fa-chevron-down"></span></a>
                        <ul className="nav child_menu">
                            <li><NavLink to={'/account1'} activeClassName='active'>Tracking Account 1 </NavLink></li>
                            <li><NavLink to={'/account2'} activeClassName='active'>Tracking Account 2 </NavLink></li>
                        </ul>
                    </li>
                    <li><a><i className="fa fa-edit"></i> Closed <span className="fa fa-chevron-down"></span></a>
                        <ul className="nav child_menu">
                            <li><NavLink to={'/account1'} activeClassName='active'>Closed Account 1 </NavLink></li>
                            <li><NavLink to={'/account2'} activeClassName='active'>Closed Account 2 </NavLink></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>;
    }
}
