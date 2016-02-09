﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by The HDF Group.                                               *
 * Copyright by the Board of Trustees of the University of Illinois.         *
 * All rights reserved.                                                      *
 *                                                                           *
 * This file is part of HDF5.  The full HDF5 copyright notice, including     *
 * terms governing use, modification, and redistribution, is contained in    *
 * the files COPYING and Copyright.html.  COPYING can be found at the root   *
 * of the source code distribution tree; Copyright.html can be found at the  *
 * root level of an installed copy of the electronic HDF5 document set and   *
 * is linked from the top-level documents page.  It can also be found at     *
 * http://hdfgroup.org/HDF5/doc/Copyright.html.  If you do not have          *
 * access to either file, you may request a copy from help@hdfgroup.org.     *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDF.PInvoke;

using hsize_t = System.UInt64;

#if HDF5_VER1_10
using hid_t = System.Int64;
#else
using hid_t = System.Int32;
#endif

namespace UnitTests
{
    public partial class H5STest
    {
        [TestMethod]
        public void H5Screate_simpleTest1()
        {
            hsize_t[] dims = { 1, 2, 3 };
            hid_t space =  H5S.create_simple(dims.Length, dims, dims);

            Assert.IsTrue(space > 0);
            Assert.IsTrue(H5S.close(space) >= 0);
        }

        [TestMethod]
        public void H5Screate_simpleTest2()
        {
            hsize_t[] dims = { 1, 2, 3 };
            hid_t space = H5S.create_simple(dims.Length, dims, dims);

            Assert.IsTrue(space > 0);
            Assert.IsTrue(H5S.close(space) >= 0);
        }

        [TestMethod]
        public void H5Screate_simpleTest3()
        {
            hsize_t[] dims = { 1, 2, 3, 0 };
            hid_t space = H5S.create_simple(dims.Length, dims, dims);

            Assert.IsTrue(space > 0);
            Assert.IsTrue(H5S.close(space) >= 0);
        }

        [TestMethod]
        public void H5Screate_simpleTest4()
        {
            hsize_t[] dims = { 1, 2, 3 };
            hsize_t[] max_dims = { H5S.UNLIMITED, H5S.UNLIMITED, H5S.UNLIMITED };
            hid_t space = H5S.create_simple(dims.Length, dims, max_dims);

            Assert.IsTrue(space > 0);
            Assert.IsTrue(H5S.close(space) >= 0);
        }

        [TestMethod]
        public void H5Screate_simpleTest5()
        {
            hsize_t[] dims = { 1, 2, 3, 0 };
            hsize_t[] max_dims = { 1, H5S.UNLIMITED, 3, 0 };
            hid_t space = H5S.create_simple(dims.Length, dims, max_dims);

            Assert.IsTrue(space > 0);
            Assert.IsTrue(H5S.close(space) >= 0);
        }
    }
}
