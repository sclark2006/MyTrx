import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class SideNavMenu extends React.Component<{}, {}> {
    public render() {
        return <div id="sidebar-menu" className="main_menu_side hidden-print main_menu">
            <div className="menu_section">
                <h3>General</h3>
                <ul className="nav side-menu">
                    <li>
                        <NavLink to={'/'} exact className='active'>
                            <i className="fa fa-home"></i> Dashboard 
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/budget'}>
                            <i className="fa fa-home"></i> Budget
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/transactions'} >
                            <i className="fa fa-home"></i> All Accounts
                        </NavLink>
                    </li>
                    <li><a><i className="fa fa-edit"></i> Budget <span className="fa fa-chevron-down"></span></a>
                        <ul className="nav child_menu">
                            <li><NavLink to={'/account1'}>Account 1 </NavLink></li>
                            <li><NavLink to={'/account2'}>Account 2 </NavLink></li>
                        </ul>
                    </li>
                    <li><a><i className="fa fa-edit"></i> Tracking <span className="fa fa-chevron-down"></span></a>
                        <ul className="nav child_menu">
                            <li><NavLink to={'/account1'} >Tracking Account 1 </NavLink></li>
                            <li><NavLink to={'/account2'} >Tracking Account 2 </NavLink></li>
                        </ul>
                    </li>
                    <li><a><i className="fa fa-edit"></i> Closed <span className="fa fa-chevron-down"></span></a>
                        <ul className="nav child_menu">
                            <li><NavLink to={'/account1'} >Closed Account 1 </NavLink></li>
                            <li><NavLink to={'/account2'} >Closed Account 2 </NavLink></li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>;
    }
}
