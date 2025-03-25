import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Home from './Components/Home';
import Layout from './Components/Layout';
import Doctors from './Components/Doctors';
import DoctorsLayout from './Components/DoctorsLayout';
import DoctorDetail from './Components/DoctorDetail';
import { loader as DoctorsLoader } from './loader/doctorsLoader';
import { loader as DoctorLoader } from './loader/doctorLoader';
import { loader as NursesLoader } from './loader/nursesLoader';
import { loader as departmentDoctorsLoader } from './loader/departmentDoctorsLoader';
import { loader as NurseLoader } from './loader/nurseLoader';
import { loader as departmentLoader } from './loader/departmentLoader';
import { loader as tokenLoader } from './loader/auth';
import { checkAuthLoader } from './loader/auth';
import { loader as ProfileLoader } from './loader/ProfileLoader';
import { loader as MyAppointmentsLoader } from './loader/MyAppointmentsLoader';
import { homeLoader } from './loader/homeLoader';
import DepartmentDoctor from './Components/DepartmentDoctor';
import Nurses from './Components/Nurses';
import NursesLayout from './Components/NursesLayout';
import AboutUs from './Components/AboutUs';
import NurseDetail from './Components/NurseDetail';
import BookingDoctor from './Components/BookingDoctor';
import { action as bookingActionDoctor } from './actions/bookingActionDoctor';
import { action as bookingActionNurse } from './actions/bookingActionNurse';
import { action as SignUpAction } from './actions/SignUpAction';
import { action as LoginAction } from './actions/LoginAction';
import { action as LogoutAction } from './actions/Logout';
import { action as ProfileAction } from './actions/ProfileAction';
import { action as sendEmailAction } from './actions/sendEmailAction';
import { action as verifyTokenAction } from './actions/verifyTokenAction';
import { action as CheckTokenAction } from './actions/CheckTokenAction';
import { action as confirmPasswordAction } from './actions/confirmPasswordAction';
import { action as DeleteBookingAction } from './actions/DeleteBookingAction';
import { action as DeleteNurseBooking } from './actions/DeleteNurseBooking';
import BookingMainForm from './Components/BookingMainForm';
import LoginBage from './Components/LoginBage';
import SignUpBage from './Components/SignUpBage';
import Profile from './Components/Profile';
import ProfileLayout from './Components/ProfileLayout';
import ChangePassword from './Components/ChangePassword';
import MyAppointments from './Components/MyAppointments';
import Error from './Components/Error';
import ForgotPassword from './Components/ForgotPassword';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Layout />,
    errorElement: <Error />,
    id: "root",
    loader: tokenLoader,
    children: [
      {
        index: true,
        element: <Home />,
        loader: homeLoader,
      },
      {
        path: ":departmentId/doctors",
        element: <DepartmentDoctor />,
        loader: departmentDoctorsLoader
      },
      {
        path: 'doctors',
        element: <DoctorsLayout />,
        children: [
          {
            index: true,
            element: < Doctors />,
            loader: DoctorsLoader,
          },
          {
            path: ":doctorId",
            element: <DoctorDetail />,
            loader: DoctorLoader
          }
        ]
      },
      {
        path: "nurses",
        element: < NursesLayout />,
        children: [
          {
            index: true,
            element: < Nurses />,
            loader: NursesLoader,
          },
          {
            path: ":nurseId",
            element: <NurseDetail />,
            loader: NurseLoader
          }
        ]
      },
      {
        path: "about-us",
        element: <AboutUs />
      },
      {
        path: "Booking",
        id:"Profile",
        loader: ProfileLoader,
        children: [
          {
            index: true,
            element: <BookingMainForm />,
            loader: departmentLoader,
          },
          {
            path: "doctors/:doctorId",
            element: <BookingDoctor type="doctor"/>,
            action: bookingActionDoctor,
            loader: checkAuthLoader
          },
          {
            path: "nurses/:nurseId",
            element: <BookingDoctor  type="nurse"/>,
            action: bookingActionNurse,
            loader: checkAuthLoader
          }
        ]
      },
      {
        path: "Account",
        children: [
          {
            path: "login",
            element: <LoginBage />,
            action: LoginAction,
          },
          {
            path: "forgotPassword",
            element: <ForgotPassword />,
            children: [
              { path: "send-email", action: sendEmailAction },
              { path: "Check-token", action: CheckTokenAction },
              { path: "change-password", action: confirmPasswordAction }
            ]
          },
          {
            path: "signUp",
            element: <SignUpBage />,
            action: SignUpAction
          },
          {
            path: "Profile",
            element: <ProfileLayout />,
            loader: checkAuthLoader,
            children: [
              {
                index: true,
                element: <Profile />,
                action: ProfileAction,
                loader: ProfileLoader
              },
              {
                path: "ChangePassword",
                element: <ChangePassword />,
                loader: ProfileLoader,
                children: [
                  { path: "send-email", action: sendEmailAction },
                  { path: "verify-token", action: verifyTokenAction },
                  { path: "change-password", action: confirmPasswordAction }
                ]
              }
            ]
          },
          {
            path: "MyAppointments",
            element: <MyAppointments />,
            loader: async (args) => {
              checkAuthLoader(args);
              return MyAppointmentsLoader(args);
            },
            children: [
              {
                path: "DeleteDoctorBooking",
                action: DeleteBookingAction
              },
              {
                path: "DeleteNurseBooking",
                action: DeleteNurseBooking
              }
            ]
          }
        ]
      },
      {
        path: "logout",
        loader: checkAuthLoader,
        action: LogoutAction
      },
      {
        path: '*', // التقاط أي مسار غير معروف
        element: <Error />
      }
    ]
  }
]);

function App() {
  return <RouterProvider router={router} />;
}

export default App;

